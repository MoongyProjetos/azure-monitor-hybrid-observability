# 🧪 Laboratório Hands-on 9 – Criação de Workbooks e Dashboards por Perfil

## 🎯 Objetivos do Laboratório

* Criar dashboards no Azure Monitor.
* Criar Workbooks para Application Owners.
* Criar Workbooks para IT Ops / SRE.
* Utilizar métricas e queries KQL em visualizações.
* Aplicar boas práticas de visualização por persona.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

A organização possui:

* Aplicações monitoradas (Application Insights)
* Servidores Azure + Arc
* AKS
* Storage e SQL

A equipe precisa:

* Dashboard executivo rápido
* Workbook de aplicação
* Workbook de infraestrutura

---

# Parte 1 — Criar Dashboard Geral

## Passo 1 — Novo Dashboard

Azure Portal → **Dashboard** → New dashboard

Nome:

**dashboard-operacional**

Layout:

* 2–3 colunas

---

## Passo 2 — Adicionar Métrica App

Add tile → Metrics

Resource: Application Insights

Metric:

* Requests
* Failed requests
* Response time

---

## Passo 3 — Adicionar CPU Infra

Add tile → Metrics

Resource: VM / Arc

Metric:

* CPU %

---

## Passo 4 — Adicionar Alertas

Add tile → Alerts

Mostrar:

* Alertas ativos

---

# Parte 2 — Workbook Application Owners

## Passo 5 — Criar Workbook

Azure Monitor → **Workbooks** → New

Nome:

**wb-app-observability**

---

## Passo 6 — Latência

Add → Query

```kql
requests
| summarize avg(duration), p95=percentile(duration,95) by name
```

Visual:

* Bar chart

---

## Passo 7 — Taxa de erro

```kql
requests
| summarize total=count(), failures=countif(success==false) by name
| extend errorRate = failures*100.0/total
```

Visual:

* Table

---

## Passo 8 — Requests no tempo

```kql
requests
| summarize count() by bin(timestamp, 5m)
```

Visual:

* Time chart

---

# Parte 3 — Workbook IT Ops / SRE

## Passo 9 — Novo Workbook

Nome:

**wb-infra-observability**

---

## Passo 10 — CPU por servidor

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by Computer
```

Visual:

* Bar

---

## Passo 11 — Servidores offline

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

Visual:

* Table

---

## Passo 12 — Erros por servidor

```kql
Event
| where EventLevelName == "Error"
| summarize count() by Computer
```

Visual:

* Bar

---

# Parte 4 — Seções e Layout

## Passo 13 — Organizar

Adicionar seções:

**Saúde Geral**
**Performance**
**Falhas**
**Capacidade**

---

# Parte 5 — Filtros por Persona

## Passo 14 — Parâmetro Recurso

Add parameter:

* Resource
* Application

Permitir filtrar queries.

---

# Parte 6 — Salvar e Compartilhar

## Passo 15 — Save

Salvar:

* Subscription
* Resource group

---

## Passo 16 — Share

Compartilhar com:

* Ops
* Dev
* SRE

---

# Parte 7 — Comparação Dash vs Workbook

Perguntas:

* Dashboard para quê?
* Workbook para quê?
* Quem usa cada um?

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Criar dashboard Azure Monitor
* Criar workbook App
* Criar workbook Infra
* Usar KQL em visualizações
* Organizar por persona
* Aplicar boas práticas

---

# 🧠 Discussão Final

Perguntas orientadoras:

* O que cada persona precisa ver?
* O que exige ação?
* Métrica vs log no dashboard?
* Nível de detalhe ideal?

---

# 🚀 Extensão (Opcional)

Top endpoints lentos:

```kql
requests
| summarize p95=percentile(duration,95) by name
| sort by p95 desc
```