# 🧪 Laboratório Hands-on 3 – Application Insights, App Service e Análise de Telemetria

## 🎯 Objetivos do Laboratório

* Criar e configurar Application Insights.
* Integrar Application Insights com App Service.
* Gerar telemetria de aplicação.
* Analisar métricas, logs e traces.
* Identificar problemas de performance e falhas.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma equipa de desenvolvimento publicou uma aplicação Web no Azure App Service e precisa:

* Monitorar performance e erros
* Identificar dependências externas
* Analisar experiência do utilizador
* Detetar falhas após deploy

---

# Parte 1 — Criar Application Insights

## Passo 1 — Criar recurso

Azure Portal → **Application Insights** → Create

Configuração:

* Name: ai-appservice-lab
* Resource Group: rg-monitoring-lab
* Region: West Europe
* Workspace-based: Yes
* Log Analytics: law-monitoring-lab

👉 Create

---

# Parte 2 — Criar App Service

## Passo 2 — Criar Web App

Azure Portal → **App Services** → Create

Configuração:

* Name: app-monitoring-lab-<id>
* Runtime: .NET / Node / Python (qualquer)
* Region: West Europe
* Plan: Basic

👉 Create

---

# Parte 3 — Integrar Application Insights

## Passo 3 — Ativar no App Service

App Service → **Application Insights**

Selecionar:

* Enable
* Existing
* ai-appservice-lab

👉 Apply

---

# Parte 4 — Gerar Telemetria

## Passo 4 — Aceder à aplicação

Abrir:

App Service → **Browse**

Realizar ações:

* Abrir página inicial
* Recarregar várias vezes
* Navegar endpoints
* Gerar 404 (URL inválido)

Exemplo:

```
/test
/error
/api/unknown
```

Objetivo:

Gerar requests, erros e traces.

---

# Parte 5 — Explorar Métricas

## Passo 5 — Overview

Application Insights → **Overview**

Observar:

* Requests
* Failures
* Response time
* Users

Perguntas:

* Há falhas?
* Qual tempo médio?
* Quantos requests?

---

# Parte 6 — Performance

## Passo 6 — Performance

Application Insights → **Performance**

Identificar:

* Operações mais lentas
* Percentil P95
* Tempo médio

Perguntas:

* Qual endpoint mais lento?
* Diferença média vs P95?

---

# Parte 7 — Failures

## Passo 7 — Failures

Application Insights → **Failures**

Observar:

* Requests falhados
* Exceções
* Códigos HTTP

Esperado:

* 404 gerados
* Possíveis 500

---

# Parte 8 — Application Map

## Passo 8 — Map

Application Insights → **Application Map**

Visualizar:

* Serviço principal
* Dependências
* Latência

Perguntas:

* Há dependências externas?
* Qual a latência?

---

# Parte 9 — Logs (KQL)

## Passo 9 — Requests

Application Insights → **Logs**

```kql
requests
| sort by timestamp desc
| take 20
```

Ver:

* Name
* ResultCode
* Duration

---

## Passo 10 — Failures

```kql
requests
| where success == false
| sort by timestamp desc
```

---

## Passo 11 — Dependências

```kql
dependencies
| take 20
```

---

## Passo 12 — Tempo de resposta

```kql
requests
| summarize avg(duration), p95=percentile(duration,95) by name
| sort by p95 desc
```

---

# Parte 10 — Análise de Experiência do Utilizador

Objetivo: correlacionar telemetria com UX.

Perguntas:

* Qual operação mais usada?
* Qual mais lenta?
* Qual mais falha?
* O utilizador percebe lentidão?

---

# Parte 11 — Simular Problema (Opcional)

Gerar carga:

Recarregar página rapidamente 20–30 vezes.

Observar:

* Requests/sec
* Latência
* Falhas

---

# ✅ Resultados Esperados

No final do laboratório, o formando deverá:

* Ter App Service monitorado
* Ter telemetria no Application Insights
* Identificar requests e falhas
* Consultar logs via KQL
* Identificar endpoint lento
* Compreender experiência do utilizador

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Métrica vs log em aplicações?
* O que indica UX degradada?
* Como detetar regressão após deploy?
* Qual dado é mais crítico para SRE?

---

# 🚀 Extensão (Opcional)

Query de falhas por endpoint:

```kql
requests
| where success == false
| summarize count() by name
| sort by count_ desc
```