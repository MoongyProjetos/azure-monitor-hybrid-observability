# 📘 Sessão 6 – Observabilidade de Containers e Workloads

---

## 🎯 Objetivos da Sessão

* Compreender os desafios de monitoramento em ambientes containerizados.
* Monitorar clusters AKS com Container Insights.
* Analisar métricas e logs de workloads.
* Monitorar Azure Container Instances (ACI).
* Monitorar Azure Container Registry (ACR).
* Definir padrão organizacional para observabilidade de containers.

---

# 🧠 Parte 1 – Por que Containers Mudam a Observabilidade?

Pergunta para o grupo:

> O que acontece quando um pod morre?

Em VM tradicional:
Você investigava a máquina.

Em Kubernetes:
O pod pode desaparecer.
Logs podem sumir.
IP pode mudar.
Escala pode variar.

Container exige:

* Monitoramento dinâmico
* Observabilidade distribuída
* Correlação entre camadas

---

# ☸️ Azure Kubernetes Service (AKS)

AKS adiciona complexidade:

* Cluster
* Nodes
* Pods
* Containers
* Namespaces
* Serviços
* Ingress

Pergunta estratégica:

> Vocês monitoram cluster ou workload?

---

# 📊 Container Insights

Container Insights permite:

* Métricas de node (CPU, memória)
* Métricas de pod
* Restart de containers
* Uso de recursos por namespace
* Análise de consumo ao longo do tempo

Ele conecta:

Infra + workload + aplicação.

---

## O que Monitorar em AKS?

### 🔹 Nível Cluster

* Saúde dos nodes
* Uso de CPU/memória
* Pressão de recursos

### 🔹 Nível Pod

* Restart count
* CrashLoopBackOff
* OOMKilled
* Pending por falta de recurso

### 🔹 Nível Workload

* Latência
* Taxa de erro
* Consumo anormal

---

# 🛠️ Hands-on 1 – Investigando um Problema em AKS

Simular:

* Pod com restart frequente
* Uso alto de memória
* Container OOMKilled

Investigar:

1. Métrica de consumo
2. Logs do container
3. Correlação com aplicação

Isso ensina investigação moderna.

---

# 📦 Azure Container Instances (ACI)

ACI é mais simples, mas precisa monitoramento.

Monitorar:

* Estado do container
* Logs de execução
* Falhas de inicialização
* Consumo de CPU/memória

Pergunta estratégica:

> ACI é workload temporário ou crítico?

Isso define nível de alerta.

---

# 🗂️ Azure Container Registry (ACR)

ACR muitas vezes é ignorado.

Mas impacta:

* Deploy
* Pipeline
* Segurança

Monitorar:

* Falhas de pull
* Latência
* Tentativas de acesso
* Uso de armazenamento
* Segurança de imagem

Pergunta estratégica:

> Existe monitoramento de falhas de pull em produção?

---

# 📈 Disponibilidade e Performance de Workloads

Aqui você conecta tudo:

Aplicação rodando em container precisa:

* Application Insights
* Container Insights
* Alertas inteligentes
* Correlação entre camadas

Modelo ideal:

```
Aplicação → Application Insights
Container → Container Insights
Infra → Métricas do cluster
Logs → Log Analytics
```

Isso é observabilidade completa.

---

# 🧩 Discussão Estratégica (15 min)

Perguntas importantes:

1. AKS é considerado crítico?
2. Existe padrão de namespace?
3. Existe limite de recursos padronizado?
4. Existe alerta para restart excessivo?
5. Existe padrão mínimo de monitoramento para novos workloads?

Aqui você começa a preencher a seção de Containers no documento estratégico.

---

# 🧠 Conexão com Sessão 7

Agora você já cobriu:

* Aplicações
* Dados
* Containers

Próximo passo:

> Expandir para infraestrutura híbrida e padronização organizacional com Azure Arc.

---

# 🎯 Resultado Esperado da Sessão 6

Ao final desta sessão:

* O grupo entende que container exige estratégia própria.
* AKS deixa de ser monitorado como VM.
* Restart e consumo passam a ser sinais críticos.
* A empresa começa a discutir padrão mínimo para workloads modernos.
