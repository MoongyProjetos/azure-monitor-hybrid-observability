# 🧪 Laboratório Hands-on 4 – Alertas Inteligentes no Application Insights

## 🎯 Objetivos do Laboratório

* Criar alertas de métricas no Application Insights.
* Criar alertas baseados em logs (KQL).
* Explorar Smart Detection.
* Configurar Dynamic Thresholds.
* Analisar causa raiz com telemetria correlacionada.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma aplicação Web em App Service já está integrada ao Application Insights.

A equipe de SRE precisa:

* Detectar aumento de falhas
* Detectar degradação de performance
* Reduzir falsos positivos
* Receber alertas acionáveis

---

# Parte 1 — Explorar Smart Detection

## Passo 1 — Abrir Smart Detection

Application Insights → **Investigate → Smart Detection**

Verificar:

* Performance anomalies
* Failure anomalies
* Dependency anomalies

---

## Passo 2 — Analisar Insight

Abrir um insight disponível.

Observar:

* Período da anomalia
* Magnitude do desvio
* Impacto em usuários
* Operações afetadas

Perguntas:

* O que mudou?
* Quando começou?
* Qual operação impactada?

---

# Parte 2 — Alerta de Métrica com Dynamic Threshold

## Passo 3 — Criar alerta

Application Insights → **Alerts → Create → Alert rule**

Selecionar:

**Signal:** Server response time

---

## Passo 4 — Configurar Dynamic Threshold

Condition:

* Threshold type: Dynamic
* Sensitivity: Medium
* Aggregation: Avg
* Evaluation: 5 min

Objetivo:

Detectar latência anormal automaticamente.

---

## Passo 5 — Action Group

Criar:

* Name: ag-appinsights
* Action: Email

---

## Passo 6 — Detalhes

* Name: alert-latency-dynamic
* Severity: 2

👉 Create

---

# Parte 3 — Alerta de Falhas (Métrica)

## Passo 7 — Novo alerta

Signal:

**Failed requests**

Condição:

* Operator: Greater than
* Threshold: 5
* Aggregation: 5 min

Objetivo:

Detectar aumento de erros.

---

# Parte 4 — Alerta Baseado em Logs (KQL)

## Passo 8 — Criar alerta KQL

Application Insights → **Logs**

Query:

```kql
requests
| where success == false
| summarize failures = count() by bin(timestamp, 5m)
| where failures > 10
```

👉 New alert rule

---

## Passo 9 — Configurar

* Frequency: 5 min
* Lookup period: 5 min
* Threshold: > 0 results

Name:

**alert-failures-kql**

---

# Parte 5 — Simular Problema

## Passo 10 — Gerar falhas

Abrir app:

```
/error
/test
/invalid
```

Ou endpoint inexistente:

```
/api/doesnotexist
```

Repetir várias vezes.

---

# Parte 6 — Validar Alertas

## Passo 11 — Verificar disparo

Azure Monitor → **Alerts**

Verificar:

* Alertas disparados
* Severidade
* Timestamp
* Resource

---

# Parte 7 — Análise de Causa Raiz

## Passo 12 — Abrir Failures

Application Insights → **Failures**

Identificar:

* Endpoint com falha
* Código HTTP
* Exceções

---

## Passo 13 — Transaction Search

Application Insights → **Transaction search**

Abrir request com erro.

Ver:

* Duração
* Dependências
* Exceções
* Cadeia completa

---

## Passo 14 — Correlacionar

Verificar:

* Latência aumentou?
* Dependência lenta?
* Exceção específica?

Objetivo:

Identificar causa provável.

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Ter alertas de latência dinâmica
* Ter alerta de falhas
* Ter alerta KQL funcional
* Identificar anomalia via Smart Detection
* Analisar causa raiz com telemetria

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Dynamic vs threshold fixo: quando usar?
* Métrica vs log para falhas?
* Smart Detection substitui alertas?
* Qual alerta indica impacto no usuário?

---

# 🚀 Extensão (Opcional)

KQL – taxa de erro por endpoint:

```kql
requests
| summarize total=count(), failures=countif(success==false) by name
| extend errorRate = failures * 100.0 / total
| sort by errorRate desc
```