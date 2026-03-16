# 🧪 Laboratório Hands-on 5 – Monitorização de Dados e Storage : Temos visibilidade suficiente sobre nossos dados críticos?

---

## 🎯 Objetivos do Laboratório

* Monitorar desempenho de Azure SQL (DTU/vCore).
* Utilizar Query Store para identificar queries problemáticas.
* Explorar SQL Insights.
* Monitorar métricas e logs de Storage Accounts.
* Definir padrão organizacional para monitoramento de dados.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização possui aplicações críticas dependentes de banco e storage.

Hoje:

* Pode monitorar CPU.
* Pode ter alertas básicos.
* Pode não ter visibilidade de query lenta.
* Pode não monitorar latência de storage.

Objetivo:

> Avaliar maturidade real na camada de dados.

---

# 🔎 Parte 0 — Diagnóstico Inicial (10 min)

Perguntas ao grupo:

1. Banco é considerado serviço crítico?
2. Existe alerta para query lenta?
3. Existe análise pós-incidente no banco?
4. Storage tem monitoramento formal?
5. Existe padrão mínimo de coleta para banco?

Registrar respostas.

---

# Parte 1 — Monitorando Azure SQL

Abrir Azure SQL Database existente.

---

## 🔹 Explorar Métricas

Ir em:

Monitoring → Metrics

Selecionar:

* DTU Percentage (se modelo DTU)
  ou
* CPU Percentage (se vCore)
* Data IO
* Log IO

---

## 🧠 Exercício Analítico

Responder:

1. Há picos de consumo?
2. O pico indica problema real?
3. Consumo alto significa erro?

Provocar:

> Métrica mostra sintoma, não causa.

---

# Parte 2 — SQL Insights

Abrir:

Azure Monitor → SQL Insights

Explorar:

* Uso de CPU
* Consumo de IO
* Tendência de carga
* Bancos com maior consumo

Pergunta estratégica:

> Monitoramos instância ou apenas database isolado?

---

# Parte 3 — Query Store

Abrir:

Azure SQL → Query Performance Insight
ou
Query Store (dependendo da interface)

---

## 🔹 Identificar Query Lenta

Procurar:

* Queries com maior duração média
* Queries com maior consumo de recursos
* Queries com regressão

---

## 🧠 Cenário Guiado

Simular:

* Query com alto tempo de execução
* Aumento de DTU

Perguntar:

1. O problema é infraestrutura?
2. Ou plano de execução?
3. Ou índice ausente?

Aqui você ensina investigação madura.

---

# Parte 4 — Criar Alerta para Banco

Criar alerta:

* DTU > 80% por 10 minutos
  ou
* CPU > 75%

Pergunta estratégica:

> Esse alerta deve ser crítico ou apenas warning?

---

# Parte 5 — Monitorando Storage Accounts

Abrir Storage Account.

Ir em:

Monitoring → Metrics

---

## 🔹 Métricas Críticas

Selecionar:

* Availability
* Success E2E Latency
* Transactions
* Throttling

---

## 🧠 Exercício Analítico

Responder:

1. Existe latência acima do normal?
2. Existe throttling?
3. Storage pode impactar aplicação silenciosamente?

---

# Parte 6 — Logs de Storage

Se diagnostic settings estiverem ativos:

Abrir Log Analytics → Logs

Query exemplo:

```kql
StorageBlobLogs
| take 20
```

Perguntar:

* Há erros 403?
* Há falhas de autenticação?
* Há padrão anômalo?

---

# 🧠 Discussão Estratégica

Perguntas finais:

1. Banco deve ter monitoramento obrigatório?
2. Query Store deve estar sempre habilitado?
3. Storage crítico deve ter alerta de latência?
4. Quem é responsável por banco?
5. Existe SLA formal para dados?

Registrar decisões preliminares.

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ Monitoramento mínimo obrigatório para banco
✔ Monitoramento mínimo obrigatório para storage
✔ Alertas críticos definidos
✔ Query Store obrigatório para produção

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Métricas de banco analisadas.
* Query Store explorado.
* SQL Insights compreendido.
* Storage monitorado.
* Primeiras decisões organizacionais tomadas.
* Camada de dados integrada à estratégia.

---

# 🚀 Extensão Opcional

Criar gráfico KQL:

```kql
AzureMetrics
| where ResourceProvider == "MICROSOFT.SQL"
| summarize avg(Average) by bin(TimeGenerated, 5m)
| render timechart
```

Perguntar:

> Métrica sozinha resolve investigação?

Provocar maturidade.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

Banco monitorado superficialmente
em
Camada de dados integrada à observabilidade estratégica.
