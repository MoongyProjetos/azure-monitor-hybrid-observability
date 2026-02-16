# 🧪 Laboratório Hands-on 8 – Alertas e Consultas Híbridas com KQL

## 🎯 Objetivos do Laboratório

* Consultar dados híbridos (Azure + Arc) com KQL.
* Identificar servidores com alto consumo de CPU.
* Detectar servidores offline via Heartbeat.
* Criar alertas baseados em logs (KQL).
* Validar monitoramento centralizado.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

A organização possui servidores:

* VMs no Azure
* Servidores on-premises via Azure Arc

Todos enviando dados ao mesmo Log Analytics.

A equipe de operações precisa:

* Detectar saturação
* Detectar servidores offline
* Criar alertas globais
* Monitorar toda a infraestrutura

---

# Parte 1 — Validar Ambiente Híbrido

## Passo 1 — Ver servidores no Log Analytics

Log Analytics → Logs

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| sort by Computer asc
```

Confirmar:

* Servidores Azure
* Servidores Arc

---

# Parte 2 — CPU por Servidor

## Passo 2 — CPU média

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer
| sort by avgCPU desc
```

---

## Exercício

Identificar:

* Servidor mais carregado
* Diferença entre Azure e Arc
* Tendência geral

---

# Parte 3 — Servidores com CPU Alta

## Passo 3 — Filtro > 80%

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer, bin(TimeGenerated, 5m)
| where avgCPU > 80
```

---

# Parte 4 — Servidores Offline

## Passo 4 — Heartbeat

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

Interpretação:

* VM parada
* Servidor offline
* Falha AMA

---

# Parte 5 — Eventos Críticos

## Passo 5 — Errors por servidor

```kql
Event
| where EventLevelName == "Error"
| summarize Errors=count() by Computer
| sort by Errors desc
```

---

# Parte 6 — Correlação CPU + Erros

## Passo 6 — CPU e eventos

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

Objetivo:

Detectar servidores críticos.

---

# Parte 7 — Criar Alerta CPU Híbrido

## Passo 7 — Query alerta

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer, bin(TimeGenerated, 5m)
| where avgCPU > 80
```

👉 New alert rule

Configurar:

* Frequency: 5 min
* Period: 5 min
* Trigger: > 0 results

Name:

**alert-hybrid-cpu**

---

# Parte 8 — Alerta Servidor Offline

## Passo 8 — Query offline

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

👉 New alert rule

Name:

**alert-server-offline**

---

# Parte 9 — Validar Alertas

Azure Monitor → **Alerts**

Verificar:

* Regras criadas
* Escopo híbrido
* Severidade
* Estado

---

# Parte 10 — Análise Operacional

Perguntas:

* Qual servidor mais crítico?
* Há offline?
* Azure vs Arc diferença?
* CPU correlaciona com erros?

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Consultar ambiente híbrido via KQL
* Identificar CPU alta
* Detectar offline
* Correlacionar métricas e eventos
* Criar alertas híbridos
* Validar monitoramento centralizado

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Benefício do workspace único?
* KQL substitui métricas?
* Offline vs CPU alto?
* Escala híbrida?

---

# 🚀 Extensão (Opcional)

Top servidores por erros:

```kql
Event
| where EventLevelName == "Error"
| summarize count() by Computer
| sort by count_ desc
```