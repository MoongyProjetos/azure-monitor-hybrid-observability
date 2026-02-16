# 🧪 Laboratório Hands-on 1 – Introdução ao Log Analytics e Métricas no Azure Monitor

## 🎯 Objetivos do Laboratório

* Criar um Log Analytics Workspace.
* Explorar métricas nativas de um recurso Azure.
* Consultar logs com KQL básico.
* Correlacionar métricas e logs para análise operacional.

---

## ⏱️ Duração Estimada

60–75 minutos

---

## 📋 Cenário

Uma equipa de operações pretende começar a monitorizar recursos Azure de forma centralizada.

O objetivo é:

* Criar um workspace de logs
* Ligar um recurso Azure
* Explorar métricas e logs
* Identificar sinais operacionais básicos

---

# Parte 1 — Criar Log Analytics Workspace

## Passo 1 — Criar o Workspace

1. Acessar o **Azure Portal**
2. Procurar **Log Analytics workspaces**
3. Selecionar **Create**

Configuração:

* **Subscription:** (sua subscrição)
* **Resource Group:** rg-monitoring-lab
* **Name:** law-monitoring-lab
* **Region:** West Europe

👉 Criar

---

## Passo 2 — Explorar o Workspace

Após criação:

Abrir o workspace → menu esquerdo:

* Logs
* Usage and estimated costs
* Agents
* Tables

Explorar separador **Tables**:

Identificar tipos de dados disponíveis:

* Heartbeat
* AzureActivity
* InsightsMetrics

---

# Parte 2 — Ligar um Recurso Azure

## Opção simples (recomendado para formação)

Usar um recurso existente, por exemplo:

* Storage Account
* App Service
* VM

---

## Passo 3 — Ativar Diagnostic Settings

1. Abrir o recurso
2. Menu **Monitoring → Diagnostic settings**
3. Selecionar **Add diagnostic setting**

Configuração:

* **Name:** send-to-law
* Selecionar logs e métricas disponíveis
* Destination: **Log Analytics workspace**
* Selecionar **law-monitoring-lab**

👉 Save

---

# Parte 3 — Explorar Métricas

## Passo 4 — Abrir Métricas

No recurso:

**Monitoring → Metrics**

Selecionar:

* Metric namespace
* Metric
* Aggregation

Exemplos:

**Storage**

* Transactions
* Availability
* Success E2E Latency

**App Service**

* Requests
* Response time
* CPU time

---

## Exercício

Responder:

1. Qual a métrica com maior variação?
2. Existe algum pico visível?
3. Qual o intervalo temporal analisado?

---

# Parte 4 — Consultar Logs (KQL)

## Passo 5 — Abrir Logs

Abrir:

Log Analytics Workspace → **Logs**

---

## Query 1 — Eventos do Azure

```kql
AzureActivity
| take 50
```

Objetivo:

Visualizar eventos de controlo (create, update, delete).

---

## Query 2 — Heartbeat

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
```

Objetivo:

Ver máquinas que enviaram dados recentemente.

---

## Query 3 — Métricas no Log Analytics

```kql
InsightsMetrics
| take 50
```

Objetivo:

Ver métricas armazenadas como logs.

---

# Parte 5 — Correlação Métricas + Logs

Objetivo: perceber relação entre eventos e comportamento.

## Query — Atividades recentes

```kql
AzureActivity
| where TimeGenerated > ago(1h)
| sort by TimeGenerated desc
```

Perguntas:

* Houve alterações recentes?
* Coincidem com picos de métricas?

---

# ✅ Resultados Esperados

No final do laboratório, o formando deverá:

* Ter um Log Analytics Workspace funcional
* Ter um recurso a enviar logs e métricas
* Conseguir navegar métricas no portal
* Executar queries KQL básicas
* Entender a diferença prática entre métricas e logs

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Quando usar métricas vs logs?
* Qual é mais útil para alertas?
* Qual é mais útil para investigação?
* O que ainda falta para observabilidade completa?

---

# 🚀 Extensão (Opcional)

Se houver tempo:

Criar gráfico KQL:

```kql
AzureActivity
| summarize count() by bin(TimeGenerated, 5m)
| render timechart
```