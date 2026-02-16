# 🧪 Laboratório Hands-on 5 – Monitoramento de Azure SQL e Storage

## 🎯 Objetivos do Laboratório

* Explorar métricas do Azure SQL (DTU/vCore, CPU, IO).
* Utilizar Query Store para identificar queries.
* Ativar SQL Insights via Azure Monitor.
* Monitorar métricas de Storage Account.
* Consultar logs de Storage no Log Analytics.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma aplicação depende de:

* Banco Azure SQL
* Storage Account

A equipe precisa:

* Detectar gargalos de banco
* Identificar queries lentas
* Monitorar latência de storage
* Investigar operações

---

# Parte 1 — Preparar Recursos

## Opção A (se já existirem)

Usar:

* Azure SQL Database existente
* Storage Account existente

---

## Opção B (criar rápido)

### Criar Azure SQL

Azure Portal → **SQL Database** → Create

Configuração mínima:

* Name: sqldb-monitoring-lab
* Server: criar novo
* Compute: Basic / S0
* Region: West Europe

👉 Create

---

### Criar Storage

Azure Portal → **Storage account** → Create

* Name: stmonitoringlab<id>
* Region: West Europe
* Performance: Standard

👉 Create

---

# Parte 2 — Métricas do Azure SQL

## Passo 1 — Abrir Métricas

SQL Database → **Metrics**

Selecionar:

* DTU percentage (ou CPU % vCore)
* Data IO %
* Log IO %

Intervalo: 30 min

---

## Exercício

Responder:

* Qual métrica mais alta?
* Há saturação?
* Há pico?

---

# Parte 3 — Query Store

## Passo 2 — Abrir Query Performance

SQL Database → **Query Performance Insight**

Observar:

* Top queries
* Duração
* CPU
* Execuções

---

## Exercício

Identificar:

* Query mais cara
* Query mais frequente
* Query mais lenta

---

# Parte 4 — Ativar SQL Insights

## Passo 3 — Criar DCR SQL

Azure Portal → **SQL Insights**

👉 Enable monitoring

Selecionar:

* SQL Database
* Log Analytics: law-monitoring-lab

👉 Enable

---

## Passo 4 — Validar Dados

Log Analytics → Logs

```kql
AzureDiagnostics
| where ResourceType == "DATABASES"
| take 50
```

---

# Parte 5 — Monitorar Storage Metrics

## Passo 5 — Métricas Storage

Storage → **Metrics**

Selecionar:

* Transactions
* Success E2E Latency
* Availability

---

## Exercício

Responder:

* Latência média?
* Há erro?
* Volume de transações?

---

# Parte 6 — Ativar Logs de Storage

## Passo 6 — Diagnostic Settings

Storage → **Diagnostic settings** → Add

Selecionar:

* Blob Read
* Blob Write
* Blob Delete

Destino:

* Log Analytics → law-monitoring-lab

👉 Save

---

# Parte 7 — Consultar Logs de Storage

## Passo 7 — Queries

Log Analytics → Logs

### Operações Blob

```kql
StorageBlobLogs
| take 50
```

---

### Erros

```kql
StorageBlobLogs
| where StatusCode >= 400
```

---

### Operações por tipo

```kql
StorageBlobLogs
| summarize count() by OperationName
```

---

# Parte 8 — Correlação SQL + Storage

Objetivo: identificar gargalo de dados.

Perguntas:

* SQL saturado?
* Storage lento?
* Operações altas?
* Latência correlaciona?

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Explorar métricas do Azure SQL
* Identificar queries via Query Store
* Ter SQL Insights ativo
* Monitorar métricas de Storage
* Consultar logs de Blob
* Correlacionar dados

---

# 🧠 Discussão Final

Perguntas orientadoras:

* DTU alto significa o quê?
* CPU vs IO no SQL?
* Quando storage impacta app?
* Query Store vs SQL Insights?

---

# 🚀 Extensão (Opcional)

Top operações Blob:

```kql
StorageBlobLogs
| summarize count() by Uri
| sort by count_ desc
```