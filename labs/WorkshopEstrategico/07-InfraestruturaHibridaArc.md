# 🧪 Laboratório Hands-on 7 – Onboarding de Servidor no Azure Arc + AMA + Monitoramento

## 🎯 Objetivos do Laboratório

* Integrar um servidor ao Azure Arc.
* Instalar e validar o Azure Arc Agent.
* Implantar Azure Monitor Agent (AMA) via Arc.
* Associar Data Collection Rule ao servidor híbrido.
* Validar ingestão de logs e métricas no Log Analytics.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

Uma organização possui servidores on-premises que precisam ser monitorados no Azure Monitor.

Objetivos:

* Registrar servidor no Azure Arc
* Implantar AMA
* Coletar métricas e eventos
* Centralizar logs no Log Analytics

---

# Parte 1 — Preparar Ambiente

## Pré-requisitos

* Servidor Windows ou Linux (on-prem ou VM local)
* Acesso admin/root
* Internet outbound HTTPS (443)
* Subscription Azure
* Log Analytics Workspace

---

# Parte 2 — Registrar Servidor no Azure Arc

## Passo 1 — Abrir Azure Arc

Azure Portal → **Azure Arc** → Servers

👉 Add / Connect servers

Selecionar:

**Add a single server**

---

## Passo 2 — Gerar Script

Configurar:

* Subscription
* Resource Group: rg-monitoring-lab
* Region: West Europe
* OS: Windows ou Linux

👉 Generate script

---

## Passo 3 — Executar Script no Servidor

No servidor local:

### Windows (PowerShell admin)

```powershell
<colar script>
```

### Linux

```bash
sudo bash arc-install.sh
```

---

## Passo 4 — Validar Conexão

Azure Portal → **Azure Arc → Servers**

Esperado:

Servidor listado
Status: **Connected**

---

# Parte 3 — Implantar Azure Monitor Agent (AMA)

## Passo 5 — Abrir Servidor Arc

Azure Arc → Servers → <servidor>

Menu:

**Extensions**

👉 Add

Selecionar:

**Azure Monitor Agent**

👉 Install

---

## Passo 6 — Validar AMA

Extensions → Status:

**Provisioning succeeded**

---

# Parte 4 — Associar Data Collection Rule

## Passo 7 — Criar DCR (se necessário)

Azure → **Data Collection Rules** → Create

Configuração:

* Name: dcr-hybrid-servers
* Region: West Europe

Data sources:

Windows:

* Performance → CPU %
* Event Logs → System

Linux:

* CPU
* Syslog

Destino:

* Log Analytics → law-monitoring-lab

👉 Create

---

## Passo 8 — Associar ao Servidor Arc

DCR → **Resources** → Add

Selecionar:

Servidor Arc

👉 Apply

---

# Parte 5 — Validar Ingestão

Aguardar 5–10 min.

## Passo 9 — Heartbeat

Log Analytics → Logs

```kql
Heartbeat
| where Computer contains "<nome-servidor>"
| sort by TimeGenerated desc
```

---

## Passo 10 — Performance

```kql
Perf
| where Computer contains "<nome-servidor>"
| take 50
```

---

## Passo 11 — Eventos

```kql
Event
| where Computer contains "<nome-servidor>"
| take 50
```

---

# Parte 6 — Métricas no Portal

Servidor Arc → **Metrics**

Selecionar:

* CPU
* Memory

---

# Parte 7 — Validar Monitoramento Unificado

Comparar:

* VM Azure
* Servidor Arc

Perguntas:

* Mesmas métricas?
* Mesmos logs?
* Mesma DCR?

Objetivo:

Verificar padronização.

---

# Parte 8 — Teste Opcional

Gerar CPU no servidor:

Windows:

```powershell
while ($true) {}
```

Linux:

```bash
yes > /dev/null
```

Validar em:

* Metrics
* Perf logs

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Ter servidor registrado no Azure Arc
* Ter AMA instalado via Arc
* Ter DCR associada
* Ter dados no Log Analytics
* Ver Heartbeat/Perf/Event
* Confirmar monitoramento híbrido

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Arc vs VM Azure: diferença?
* AMA híbrido funciona igual?
* DCR reutilizável?
* Benefício da padronização?

---

# 🚀 Extensão (Opcional)

Todos servidores híbridos:

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| sort by LastSeen desc
```