# 🧪 Laboratório Hands-on 6 – Monitoramento de AKS com Container Insights

## 🎯 Objetivos do Laboratório

* Habilitar Container Insights em um cluster AKS.
* Explorar métricas de nós, pods e containers.
* Consultar logs de containers no Log Analytics.
* Identificar problemas de capacidade e estabilidade.
* Analisar disponibilidade de workloads.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma aplicação está implantada em um cluster AKS.
A equipe de operações precisa:

* Monitorar saúde do cluster
* Detectar pods com falha
* Analisar consumo de recursos
* Investigar logs de containers

---

# Parte 1 — Preparar Cluster AKS

## Opção A (se já existir)

Usar cluster existente.

---

## Opção B (criar rápido)

Azure Portal → **Kubernetes services** → Create

Configuração mínima:

* Name: aks-monitoring-lab
* Region: West Europe
* Node size: Standard_DS2_v2
* Node count: 1

👉 Create

---

# Parte 2 — Habilitar Container Insights

## Passo 1 — Ativar Insights

AKS → **Insights** → Enable

Selecionar:

* Log Analytics: law-monitoring-lab

👉 Enable

Aguardar 5–10 min para ingestão.

---

# Parte 3 — Explorar Visão do Cluster

## Passo 2 — Cluster

AKS → **Insights → Cluster**

Observar:

* CPU total
* Memory total
* Node count
* Utilização

Perguntas:

* Cluster saturado?
* Há capacidade livre?

---

# Parte 4 — Nós (Nodes)

## Passo 3 — Nodes

Insights → **Nodes**

Ver:

* CPU por node
* Memory por node
* Status

Perguntas:

* Node saturado?
* Desequilíbrio?

---

# Parte 5 — Pods

## Passo 4 — Pods

Insights → **Pods**

Observar:

* Status
* Restarts
* CPU/memory

Esperado:

* Running
* Pending
* Failed

---

# Parte 6 — Containers

## Passo 5 — Containers

Insights → **Containers**

Ver:

* CPU
* Memory
* Restarts

Perguntas:

* Container com alto consumo?
* Restarts?

---

# Parte 7 — Logs de Containers

## Passo 6 — Logs

Insights → **Logs**

Query:

```kql
ContainerLog
| take 50
```

---

## Passo 7 — Filtrar Erros

```kql
ContainerLog
| where LogEntry contains "error"
```

---

## Passo 8 — Logs por Pod

```kql
ContainerLog
| summarize count() by PodName
| sort by count_ desc
```

---

# Parte 8 — Eventos Kubernetes

## Passo 9 — Eventos

```kql
KubeEvents
| take 50
```

---

## Falhas de Pod

```kql
KubePodInventory
| where PodStatus != "Running"
```

---

# Parte 9 — Simular Problema (Opcional)

Se houver app implantada:

Escalar deployment:

```bash
kubectl scale deployment <nome> --replicas=5
```

Ou gerar carga.

Observar:

* CPU
* Pods
* Scheduling

---

# Parte 10 — Análise de Capacidade

Perguntas:

* Node próximo do limite?
* Pods Pending?
* CPU saturado?
* Memória crítica?

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Ter Container Insights ativo
* Explorar cluster/nodes/pods
* Consultar logs de containers
* Identificar pods não Running
* Avaliar capacidade do cluster
* Detectar consumo de recursos

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Saturação de node vs pod?
* Restart indica o quê?
* Quando escalar cluster?
* Logs vs métricas em containers?

---

# 🚀 Extensão (Opcional)

Top pods por CPU:

```kql
InsightsMetrics
| where Name == "cpuUsageNanoCores"
| summarize avg(Val) by Tags["podName"]
| sort by avg_Val desc
```
