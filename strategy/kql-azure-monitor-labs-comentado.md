# 📊 KQL – Azure Monitor Labs

Coleção de queries KQL utilizadas nos laboratórios do curso **Azure Monitor para Ambientes Híbridos (Azure + On-Prem)**.

Cada query inclui explicação operacional e contexto de uso.

---

# 🧱 Infraestrutura – Servidores (VM / Arc)

## Heartbeat recente

**Objetivo:** verificar se o agente está enviando dados
**Uso:** validar monitoramento ativo

```kql
Heartbeat
| where TimeGenerated > ago(10m)
| sort by TimeGenerated desc
```

👉 Se não aparecer → agente ou conectividade com problema

---

## Último heartbeat por servidor

**Objetivo:** ver último contato de cada máquina
**Uso:** visão geral da infraestrutura

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
```

👉 Permite identificar máquinas silenciosas

---

## Servidores offline

**Objetivo:** detectar máquinas sem dados recentes
**Uso:** alerta de indisponibilidade

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

👉 Pode indicar:

* VM parada
* servidor on-prem offline
* falha de agente

---

## CPU média por servidor

**Objetivo:** comparar carga entre máquinas
**Uso:** capacity planning

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer
| sort by avgCPU desc
```

👉 Top = servidores mais carregados

---

## CPU alta (>80%)

**Objetivo:** detectar saturação sustentada
**Uso:** alertas

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer, bin(TimeGenerated, 5m)
| where avgCPU > 80
```

👉 Média em janela evita falsos positivos

---

## Perf logs recentes

**Objetivo:** validar ingestão de métricas
**Uso:** troubleshooting AMA

```kql
Perf
| where TimeGenerated > ago(10m)
| take 50
```

---

## Eventos recentes

**Objetivo:** verificar eventos do sistema
**Uso:** diagnóstico

```kql
Event
| where TimeGenerated > ago(10m)
| take 50
```

---

## Eventos críticos por servidor

**Objetivo:** identificar máquinas com mais erros
**Uso:** priorização

```kql
Event
| where EventLevelName == "Error"
| summarize count() by Computer
| sort by count_ desc
```

👉 Top = servidores mais problemáticos

---

## CPU + erros (correlação)

**Objetivo:** correlacionar carga com falhas
**Uso:** análise de causa

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer
| join (
    Event
    | where EventLevelName == "Error"
    | summarize Errors=count() by Computer
) on Computer
| sort by avgCPU desc
```

👉 CPU alta + erros = candidato a incidente

---

# ☸️ Containers / AKS

## Logs de containers

**Objetivo:** visualizar stdout/stderr
**Uso:** debug de app

```kql
ContainerLog
| take 50
```

---

## Logs com erro

**Objetivo:** filtrar mensagens de erro
**Uso:** troubleshooting

```kql
ContainerLog
| where LogEntry contains "error"
```

---

## Logs por pod

**Objetivo:** identificar pods mais ruidosos
**Uso:** estabilidade

```kql
ContainerLog
| summarize count() by PodName
| sort by count_ desc
```

👉 Pod com muitos logs pode estar falhando

---

## Eventos Kubernetes

**Objetivo:** eventos do cluster
**Uso:** scheduling / falhas

```kql
KubeEvents
| take 50
```

---

## Pods não running

**Objetivo:** detectar pods com problema
**Uso:** disponibilidade

```kql
KubePodInventory
| where PodStatus != "Running"
```

👉 Status comuns:

* Pending
* Failed
* CrashLoopBackOff

---

## Top pods por CPU

**Objetivo:** consumo por pod
**Uso:** tuning / scaling

```kql
InsightsMetrics
| where Name == "cpuUsageNanoCores"
| summarize avg(Val) by Tags["podName"]
| sort by avg_Val desc
```

---

# 🌐 Application Insights – Aplicações

## Requests recentes

**Objetivo:** ver tráfego recente
**Uso:** validação de telemetria

```kql
requests
| sort by timestamp desc
| take 20
```

---

## Falhas de requests

**Objetivo:** requests com erro
**Uso:** análise de falhas

```kql
requests
| where success == false
| sort by timestamp desc
```

---

## Dependências

**Objetivo:** chamadas externas
**Uso:** latência externa

```kql
dependencies
| take 20
```

---

## Latência média e P95

**Objetivo:** performance por endpoint
**Uso:** SLO / UX

```kql
requests
| summarize avg(duration), p95=percentile(duration,95) by name
| sort by p95 desc
```

👉 P95 representa experiência do usuário

---

## Falhas por endpoint

**Objetivo:** endpoints problemáticos
**Uso:** priorização

```kql
requests
| summarize count() by name
| where success == false
| sort by count_ desc
```

---

## Taxa de erro por endpoint

**Objetivo:** qualidade por operação
**Uso:** SRE

```kql
requests
| summarize total=count(), failures=countif(success==false) by name
| extend errorRate = failures * 100.0 / total
| sort by errorRate desc
```

---

## Requests no tempo

**Objetivo:** volume de tráfego
**Uso:** carga

```kql
requests
| summarize count() by bin(timestamp, 5m)
```

---

## Detecção de falhas (alerta)

**Objetivo:** pico de erro
**Uso:** alerta

```kql
requests
| where success == false
| summarize failures = count() by bin(timestamp, 5m)
| where failures > 10
```

---

# 🗄️ Azure SQL

## Diagnósticos SQL

**Objetivo:** logs do banco
**Uso:** troubleshooting

```kql
AzureDiagnostics
| where ResourceType == "DATABASES"
| take 50
```

---

# 📦 Storage

## Logs Blob

**Objetivo:** operações de storage
**Uso:** auditoria

```kql
StorageBlobLogs
| take 50
```

---

## Erros Blob

**Objetivo:** falhas storage
**Uso:** incidentes

```kql
StorageBlobLogs
| where StatusCode >= 400
```

---

## Operações por tipo

**Objetivo:** perfil de uso
**Uso:** análise

```kql
StorageBlobLogs
| summarize count() by OperationName
```

---

## Top blobs por acesso

**Objetivo:** objetos mais usados
**Uso:** otimização

```kql
StorageBlobLogs
| summarize count() by Uri
| sort by count_ desc
```

---

# 🔔 Azure Activity

## Atividades recentes

**Objetivo:** mudanças em recursos
**Uso:** auditoria

```kql
AzureActivity
| where TimeGenerated > ago(1h)
| sort by TimeGenerated desc
```

---

## Eventos Azure

**Objetivo:** eventos de controle
**Uso:** governança

```kql
AzureActivity
| take 50
```

---

# 📊 Métricas via Logs

## Insights Metrics

**Objetivo:** métricas coletadas
**Uso:** validação

```kql
InsightsMetrics
| take 50
```

---

# 💰 Custos Log Analytics

## Uso por tabela

**Objetivo:** identificar custo
**Uso:** otimização

```kql
Usage
| summarize DataGB=sum(Quantity)/1024 by DataType
| sort by DataGB desc
```

👉 Top = maior custo

---

## Tabelas mais volumosas

**Objetivo:** ingestão total
**Uso:** governance

```kql
Usage
| summarize TotalGB=sum(Quantity)/1024 by DataType
| sort by TotalGB desc
```

---

# 🌐 Ambiente Híbrido Global

## Todos servidores

**Objetivo:** visão completa
**Uso:** inventário

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| sort by LastSeen desc
```

---

# 📘 Workbooks

## CPU por servidor

**Objetivo:** gráfico infra
**Uso:** dashboard

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by Computer
```

---

## Servidores offline (workbook)

**Objetivo:** status infra
**Uso:** NOC

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

---

## Erros por servidor

**Objetivo:** estabilidade
**Uso:** operação

```kql
Event
| where EventLevelName == "Error"
| summarize count() by Computer
```

---