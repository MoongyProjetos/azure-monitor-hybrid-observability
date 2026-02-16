# 🧪 Laboratório Hands-on 2 – Azure Monitor Agent, DCR e Alertas

## 🎯 Objetivos do Laboratório

* Instalar e validar o Azure Monitor Agent (AMA).
* Criar uma Data Collection Rule (DCR).
* Associar a DCR a uma máquina (Azure ou Arc).
* Validar ingestão de dados no Log Analytics.
* Criar um alerta baseado em métrica ou log.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma organização pretende monitorizar servidores (Azure ou on-premises via Arc) de forma centralizada.

Objetivos operacionais:

* Recolher métricas e eventos de sistema
* Centralizar logs no Log Analytics
* Criar alerta de CPU elevada

---

# Parte 1 — Preparar Ambiente

## Pré-requisitos

* Log Analytics Workspace existente
* VM Azure **ou** servidor Arc
* Permissões Contributor

---

## Passo 1 — Validar Workspace

Abrir:

Azure Portal → **Log Analytics workspaces**

Confirmar:

* Workspace disponível
* Região compatível
* Acesso ao separador Logs

---

# Parte 2 — Instalar Azure Monitor Agent (AMA)

## Passo 2 — Instalar AMA na VM

Abrir VM → **Extensions + applications** → Add

Selecionar:

**Azure Monitor Agent**

👉 Install

---

## Passo 3 — Validar Instalação

VM → Extensions

Estado esperado:

**Provisioning succeeded**

---

# Parte 3 — Criar Data Collection Rule (DCR)

## Passo 4 — Criar DCR

Azure Portal → procurar:

**Data Collection Rules**

👉 Create

Configuração:

* Name: dcr-vm-monitoring
* Resource group: rg-monitoring-lab
* Region: mesma da VM

---

## Passo 5 — Adicionar Data Source

Adicionar:

### Windows

* Performance counter:

  * Processor → % Processor Time
* Event logs:

  * System
  * Application

### Linux

* CPU
* Syslog

---

## Passo 6 — Destino

Selecionar:

**Log Analytics workspace**
→ law-monitoring-lab

👉 Create

---

# Parte 4 — Associar DCR à VM

## Passo 7 — Association

Abrir DCR criada → **Resources**

👉 Add resource

Selecionar:

VM alvo

👉 Apply

---

# Parte 5 — Validar Ingestão de Dados

## Passo 8 — Verificar Heartbeat

Log Analytics → Logs

```kql
Heartbeat
| where TimeGenerated > ago(10m)
| sort by TimeGenerated desc
```

Resultado esperado:

VM listada recentemente.

---

## Passo 9 — Verificar Performance

```kql
Perf
| where TimeGenerated > ago(10m)
| take 50
```

Verificar:

* CounterName
* Computer
* CounterValue

---

## Passo 10 — Verificar Event Logs

```kql
Event
| where TimeGenerated > ago(10m)
| take 50
```

---

# Parte 6 — Criar Alerta de CPU

## Passo 11 — Abrir Métricas da VM

VM → **Metrics**

Selecionar:

* Metric: Percentage CPU
* Aggregation: Avg

---

## Passo 12 — Criar Alerta

👉 New alert rule

Configuração:

**Condition**

* Metric: Percentage CPU
* Operator: Greater than
* Threshold: 80
* Aggregation: 5 min

**Action group**

Criar:

* Name: ag-email
* Action: Email

**Details**

* Name: alert-high-cpu
* Severity: 2

👉 Create

---

# Parte 7 — Testar Alerta (Opcional)

Na VM:

Gerar carga CPU:

### Windows

```powershell
while ($true) { }
```

### Linux

```bash
yes > /dev/null
```

Aguardar 5–10 min.

Resultado esperado:

Alerta disparado.

---

# ✅ Resultados Esperados

No final do laboratório, o formando deverá:

* Ter AMA instalado e ativo
* Ter uma DCR funcional
* Ter dados a chegar ao Log Analytics
* Conseguir consultar Perf/Event/Heartbeat
* Ter um alerta de CPU configurado

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Qual a vantagem da DCR vs configuração direta?
* O que acontece se associar a mesma DCR a 100 VMs?
* Métrica vs log: qual usar para CPU?
* Quando usar alerta de log em vez de métrica?

---

# 🚀 Extensão (Opcional)

Criar alerta baseado em log:

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by bin(TimeGenerated, 5m), Computer
| where avg_CounterValue > 80
```