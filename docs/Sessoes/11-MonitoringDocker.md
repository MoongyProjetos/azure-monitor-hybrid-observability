# 📘 Sessão 11 – Integrações, Containers, Custos e Governance

# PARTE I — LABORATÓRIO PRÁTICO: OBSERVABILIDADE END-TO-END NO AZURE

## 1. Introdução ao Laboratório

### Objetivo

Implementar uma solução completa de observabilidade para uma aplicação .NET executada em containers no Azure Kubernetes Service (AKS).

Ao longo do laboratório, iremos:

1. Criar uma aplicação ASP.NET Core.
2. Instrumentar a aplicação com OpenTelemetry.
3. Integrar com Azure Application Insights.
4. Criar uma imagem Docker.
5. Publicar a imagem no Azure Container Registry.
6. Criar um cluster Azure Kubernetes Service.
7. Executar a aplicação no Kubernetes.
8. Configurar Azure Monitor e Container Insights.
9. Consultar logs, métricas e exceptions.
10. Demonstrar mecanismos de resiliência do Kubernetes.

### Arquitetura final

```text
Developer
   |
   v
ASP.NET Core Web API
   |
   +--------------------+
   |                    |
   v                    v
OpenTelemetry        ILogger
   |                    |
   v                    v
Application Insights   STDOUT / STDERR
                            |
                            v
                       Kubernetes
                            |
                            v
                           AKS
                            |
                            v
                      Azure Monitor
                            |
                            v
                    Log Analytics Workspace
```

## 2. Pré-requisitos

Antes de iniciar, precisamos de:

- Subscrição Azure.
- Azure CLI.
- Docker Desktop.
- .NET 10 SDK.
- kubectl.
- Editor de código (Visual Studio Code ou Visual Studio).

Validar as instalações:

```bash
dotnet --version
docker --version
az version
kubectl version --client
```

Autenticar no Azure:

```bash
az login
```

Selecionar a subscrição:

```bash
az account set --subscription "SUBSCRIPTION_ID"
```

Criar as variáveis que utilizaremos durante o laboratório:

```bash
RESOURCE_GROUP="rg-monitoring-demo"
LOCATION="westeurope"
ACR_NAME="acrmonitoringdemo123"
AKS_NAME="aks-monitoring-demo"
APP_NAME="monitoringdemo"
```

Nota: o nome do ACR deve ser globalmente único e conter apenas caracteres alfanuméricos.

---

## 3. Etapa 1 — Criar a aplicação .NET

Vamos criar uma aplicação ASP.NET Core Web API.

Esta aplicação será intencionalmente simples, mas terá funcionalidades suficientes para demonstrar diferentes cenários de observabilidade.

### 3.1 Criar o projeto

```bash
dotnet new webapi -n MonitoringDemo
```

Entrar na pasta:

```bash
cd MonitoringDemo
```

### 3.2 Instalar o pacote de telemetria

Instalar o pacote Azure Monitor OpenTelemetry:

```bash
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

Este pacote permite instrumentar a aplicação e exportar dados de telemetria para o Azure Monitor.

### 3.3 Implementar os endpoints

Abrir o ficheiro `Program.cs` e substituir o conteúdo por:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure OpenTelemetry and Azure Monitor.
builder.Services
    .AddOpenTelemetry()
    .UseAzureMonitor();

var app = builder.Build();

// GET / - Hello World
app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation(
        "Hello World endpoint was called.");

    return Results.Ok(new
    {
        Message = "Hello from AKS!",
        Application = "MonitoringDemo",
        Version = "1.0.0",
        Timestamp = DateTime.UtcNow
    });
});

// GET /health - Health Check
app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy"
    });
});

// GET /error - Simulate an application error
app.MapGet("/error", (ILogger<Program> logger) =>
{
    logger.LogError(
        "Simulated application error!");

    throw new InvalidOperationException(
        "This is a simulated exception for monitoring.");
});

app.Run();
```

### 3.4 Compreender os endpoints

| Endpoint | Objetivo | Resultado esperado |
|---|---|---|
| `/` | Simular uma chamada normal | HTTP 200 |
| `/health` | Verificar disponibilidade | HTTP 200 |
| `/error` | Provocar uma exceção | HTTP 500 |

O endpoint `/error` será especialmente importante para demonstrar o registo de exceptions no Application Insights.

### 3.5 Configurar a Connection String

No Azure Portal:

1. Criar um recurso Application Insights.
2. Associar um Log Analytics Workspace.
3. Abrir o recurso Application Insights.
4. Copiar a Connection String.

Configurar a variável de ambiente:

```bash
APPLICATIONINSIGHTS_CONNECTION_STRING="YOUR_CONNECTION_STRING"
```

O SDK utiliza esta variável para identificar o destino da telemetria.

### 3.6 Executar localmente

Restaurar dependências:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Executar:

```bash
dotnet run --urls http://localhost:8080
```

Abrir outro terminal e testar:

```bash
curl http://localhost:8080/
```

```bash
curl http://localhost:8080/health
```

```bash
curl http://localhost:8080/error
```

### 3.7 Validar a telemetria

Aceder ao Application Insights e verificar:

- Requests.
- Exceptions.
- Traces.
- Performance.

Nota: a ingestão de telemetria não é necessariamente instantânea. Pode existir algum atraso até os dados aparecerem no portal.

**Resultado esperado:** aplicação funcional, com instrumentação e telemetria a chegar ao Application Insights.

---

## 4. Etapa 2 — Criar a imagem Docker

Agora vamos empacotar a aplicação num container.

### 4.1 Criar o Dockerfile

Na raiz do projeto, criar um ficheiro chamado `Dockerfile`:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY *.csproj ./

RUN dotnet restore

COPY . .

RUN dotnet publish \
    -c Release \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "MonitoringDemo.dll"]
```

### 4.2 Compreender o Dockerfile

| Instrução | Responsabilidade |
|---|---|
| FROM SDK | Ambiente de compilação |
| WORKDIR | Diretório de trabalho |
| COPY | Copiar os ficheiros |
| RUN restore | Restaurar dependências |
| RUN publish | Publicar a aplicação |
| FROM ASP.NET | Runtime da aplicação |
| EXPOSE | Documentar a porta |
| ENTRYPOINT | Iniciar a aplicação |

Estamos a utilizar um Docker Multi-Stage Build.

A primeira imagem contém o SDK e serve para compilar. A segunda contém apenas o runtime e os ficheiros publicados, reduzindo o tamanho da imagem final.

### 4.3 Criar a imagem

```bash
docker build -t monitoringdemo:v1 .
```

Listar imagens:

```bash
docker images
```

### 4.4 Executar o container

```bash
docker run -d \
  --name monitoringdemo \
  -p 8080:8080 \
  -e APPLICATIONINSIGHTS_CONNECTION_STRING="YOUR_CONNECTION_STRING" \
  monitoringdemo:v1
```

### 4.5 Testar a aplicação

```bash
curl http://localhost:8080/
```

Consultar os logs:

```bash
docker logs monitoringdemo
```

Acompanhar os logs em tempo real:

```bash
docker logs -f monitoringdemo
```

Remover o container:

```bash
docker rm -f monitoringdemo
```

**Resultado esperado:** aplicação executada num container Docker local, com logs disponíveis através do Docker.

---

## 5. Etapa 3 — Criar o Azure Container Registry

O Azure Container Registry será o repositório onde armazenaremos a imagem Docker.

### 5.1 Criar o Resource Group

```bash
az group create \
  --name $RESOURCE_GROUP \
  --location $LOCATION
```

### 5.2 Criar o ACR

```bash
az acr create \
  --resource-group $RESOURCE_GROUP \
  --name $ACR_NAME \
  --sku Basic
```

### 5.3 Autenticar no registry

```bash
az acr login --name $ACR_NAME
```

### 5.4 Criar uma tag para a imagem

```bash
docker tag monitoringdemo:v1 \
  $ACR_NAME.azurecr.io/monitoringdemo:v1
```

### 5.5 Publicar a imagem

```bash
docker push \
  $ACR_NAME.azurecr.io/monitoringdemo:v1
```

### 5.6 Validar a publicação

```bash
az acr repository list \
  --name $ACR_NAME \
  --output table
```

Consultar as tags:

```bash
az acr repository show-tags \
  --name $ACR_NAME \
  --repository monitoringdemo \
  --output table
```

**Resultado esperado:** imagem Docker publicada e disponível no Azure Container Registry.

---

## 6. Etapa 4 — Criar o Azure Kubernetes Service

Vamos criar um cluster AKS que irá executar a nossa aplicação.

### 6.1 Criar o cluster

```bash
az aks create \
  --resource-group $RESOURCE_GROUP \
  --name $AKS_NAME \
  --location $LOCATION \
  --node-count 1 \
  --node-vm-size Standard_D2s_v5 \
  --tier free \
  --enable-addons monitoring \
  --enable-azure-monitor-metrics \
  --attach-acr $ACR_NAME \
  --generate-ssh-keys
```

Esta configuração ativa:

- Azure Monitor Container Insights.
- Azure Monitor Managed Prometheus.
- Integração entre AKS e ACR.
- Um node para executar os workloads.

A criação do cluster pode demorar vários minutos.

### 6.2 Obter as credenciais

```bash
az aks get-credentials \
  --resource-group $RESOURCE_GROUP \
  --name $AKS_NAME
```

### 6.3 Validar o cluster

```bash
kubectl get nodes
```

Listar os Pods:

```bash
kubectl get pods -A
```

Listar os namespaces:

```bash
kubectl get namespaces
```

### 6.4 Explorar a infraestrutura

Explicar aos participantes:

- Cluster: conjunto de recursos Kubernetes.
- Node: máquina que executa os workloads.
- Pod: unidade mínima de execução.
- Container: processo isolado que executa a aplicação.
- Deployment: controla o estado desejado dos Pods.
- Service: disponibiliza acesso à aplicação.

**Resultado esperado:** cluster AKS criado e operacional.

---

## 7. Etapa 5 — Fazer Deploy da aplicação

Vamos executar duas réplicas da aplicação no AKS.

### 7.1 Criar o Secret

Guardar a Connection String do Application Insights num Kubernetes Secret:

```bash
kubectl create secret generic monitoring-secrets \
  --from-literal=APPLICATIONINSIGHTS_CONNECTION_STRING="YOUR_CONNECTION_STRING"
```

### 7.2 Criar o ficheiro deployment.yaml

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: monitoringdemo
spec:
  replicas: 2
  selector:
    matchLabels:
      app: monitoringdemo
  template:
    metadata:
      labels:
        app: monitoringdemo
    spec:
      containers:
        - name: monitoringdemo
          image: acrmonitoringdemo123.azurecr.io/monitoringdemo:v1
          ports:
            - containerPort: 8080
          env:
            - name: APPLICATIONINSIGHTS_CONNECTION_STRING
              valueFrom:
                secretKeyRef:
                  name: monitoring-secrets
                  key: APPLICATIONINSIGHTS_CONNECTION_STRING
          resources:
            requests:
              cpu: 100m
              memory: 128Mi
            limits:
              cpu: 500m
              memory: 512Mi
---
apiVersion: v1
kind: Service
metadata:
  name: monitoringdemo-service
spec:
  type: LoadBalancer
  selector:
    app: monitoringdemo
  ports:
    - port: 80
      targetPort: 8080
```

Nota: substituir o nome do registry pelo ACR efetivamente criado.

### 7.3 Aplicar a configuração

```bash
kubectl apply -f deployment.yaml
```

### 7.4 Verificar os Deployments

```bash
kubectl get deployments
```

### 7.5 Verificar os Pods

```bash
kubectl get pods -o wide
```

Devemos observar duas réplicas da aplicação.

### 7.6 Verificar o Service

```bash
kubectl get services
```

Aguardar que o campo EXTERNAL-IP seja preenchido.

### 7.7 Testar a aplicação

```bash
curl http://EXTERNAL-IP/
```

Testar também:

```bash
curl http://EXTERNAL-IP/health
```

E:

```bash
curl http://EXTERNAL-IP/error
```

**Resultado esperado:** aplicação publicada e acessível através do endereço público disponibilizado pelo Kubernetes.

---

## 8. Etapa 6 — Monitoring com Application Insights

Agora vamos observar o comportamento da aplicação.

### 8.1 Aceder ao Application Insights

No Azure Portal:

1. Abrir o Application Insights.
2. Aceder a Live Metrics.
3. Gerar tráfego através dos endpoints.
4. Observar os requests e a telemetria.

### 8.2 Consultar Requests

```kusto
requests
| order by timestamp desc
| project timestamp,
          name,
          resultCode,
          success,
          duration
```

### 8.3 Consultar Exceptions

```kusto
exceptions
| order by timestamp desc
| project timestamp,
          type,
          outerMessage,
          operation_Id
```

### 8.4 Consultar Traces

```kusto
traces
| order by timestamp desc
| project timestamp,
          severityLevel,
          message,
          operation_Id
```

### 8.5 Interpretar os resultados

Os participantes deverão identificar:

- Requests HTTP executados.
- Requests bem-sucedidos.
- Requests com falhas.
- Exceptions.
- Mensagens de log.
- Tempo de resposta.

**Conceito-chave:** Application Insights permite compreender o comportamento interno e funcional da aplicação.

---

## 9. Etapa 7 — Monitoring com Azure Monitor Container Insights

Nesta etapa vamos observar os containers e a infraestrutura Kubernetes.

### 9.1 Aceder ao AKS

No Azure Portal:

1. Abrir o recurso AKS.
2. Aceder à secção Monitor.
3. Abrir a visão de Containers.
4. Explorar os Nodes, Pods e Controllers.

### 9.2 Explorar métricas

Demonstrar:

- CPU Usage.
- Memory Usage.
- Pod Status.
- Container Status.
- Node Health.
- Container Restarts.

### 9.3 Consultar logs dos containers

Aceder ao Log Analytics Workspace associado ao cluster.

Executar:

```kusto
ContainerLogV2
| where PodNamespace == "default"
| where PodName startswith "monitoringdemo"
| order by TimeGenerated desc
| project TimeGenerated,
          PodName,
          ContainerName,
          LogMessage
```

### 9.4 Filtrar erros

```kusto
ContainerLogV2
| where PodName startswith "monitoringdemo"
| where LogMessage has "error"
| order by TimeGenerated desc
```

### 9.5 Comparar logs

Demonstrar a diferença:

| Application Insights | Container Insights |
|---|---|
| Application Requests | Container Logs |
| Exceptions | Pod Status |
| Application Traces | CPU / Memory |
| Dependencies | Node Health |
| Application Performance | Container Restarts |

**Conceito-chave:** Application Insights e Container Insights são complementares.

---

## 10. Etapa 8 — Demonstrar Self-Healing

Vamos provocar uma falha controlada num dos Pods.

### 10.1 Listar os Pods

```bash
kubectl get pods
```

### 10.2 Eliminar um Pod

```bash
kubectl delete pod POD_NAME
```

### 10.3 Acompanhar a recuperação

```bash
kubectl get pods -w
```

Observar como o Kubernetes cria automaticamente um novo Pod para manter o número de réplicas configurado no Deployment.

### 10.4 Relacionar com observabilidade

Consultar:

- Eventos do Kubernetes.
- Pod Status.
- Container Restarts.
- Logs.
- Estado do Deployment.

**Conceitos abordados:**

- Self-Healing.
- Resilience.
- Desired State.
- Availability.
- Infrastructure Monitoring.

---

## 11. Encerramento do Laboratório

Ao terminar, os participantes terão implementado uma solução completa:

- Aplicação .NET.
- OpenTelemetry.
- Docker.
- Azure Container Registry.
- Azure Kubernetes Service.
- Application Insights.
- Azure Monitor.
- Container Insights.
- Log Analytics.
- Consultas KQL.

A demonstração ilustra como construir uma solução de observabilidade integrada desde o código da aplicação até à infraestrutura onde esta é executada.

© MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor
