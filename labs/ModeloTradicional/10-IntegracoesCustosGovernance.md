# 🧪 Laboratório Hands-on 10 – Integrações, Custos e Governance no Azure Monitor

## 🎯 Objetivos do Laboratório

* Integrar alertas do Azure Monitor com Microsoft Teams.
* Explorar exportação de dados via Diagnostic Settings.
* Analisar consumo e custos do Log Analytics.
* Aplicar retenção e otimização de ingestão.
* Definir boas práticas de governance.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário

A organização já utiliza Azure Monitor em:

* Aplicações
* Infraestrutura Azure
* Servidores híbridos
* Containers

Agora precisa:

* Integrar alertas ao Teams
* Controlar custos
* Definir governance
* Padronizar monitoramento

---

# Parte 1 — Integração de Alertas com Microsoft Teams

## Passo 1 — Criar Webhook no Teams

No Microsoft Teams:

1. Abrir canal
2. Connectors / Workflows
3. Incoming Webhook
4. Nome: AzureMonitor
5. Copiar URL

---

## Passo 2 — Criar Action Group

Azure Portal → **Monitor → Alerts → Action groups**

Create:

* Name: ag-teams
* Type: Webhook
* URL: colar webhook Teams

👉 Create

---

## Passo 3 — Associar a Alerta

Abrir alerta existente (ex: CPU ou App).

Editar:

* Action group → ag-teams

Salvar.

---

## Passo 4 — Testar

Disparar alerta (CPU ou falha app).

Verificar:

Mensagem no Teams.

---

# Parte 2 — Exportação de Logs

## Passo 5 — Diagnostic Settings

Abrir recurso (VM / Storage / App).

**Diagnostic settings → Add**

Destino:

* Log Analytics
* Storage (opcional)
* Event Hub (opcional)

Salvar.

---

## Passo 6 — Validar Exportação

Log Analytics → Logs

```kql
AzureDiagnostics
| take 50
```

---

# Parte 3 — Análise de Custos Log Analytics

## Passo 7 — Usage and Costs

Log Analytics Workspace → **Usage and estimated costs**

Observar:

* GB/dia
* Tabelas mais volumosas
* Tendência

---

## Passo 8 — Tabelas com maior ingestão

```kql
Usage
| summarize DataGB=sum(Quantity)/1024 by DataType
| sort by DataGB desc
```

Identificar:

* Tabelas dominantes
* Fontes de custo

---

# Parte 4 — Otimização de Ingestão

## Passo 9 — Identificar logs ruidosos

```kql
Usage
| summarize TotalGB=sum(Quantity)/1024 by DataType
| sort by TotalGB desc
```

Perguntas:

* Dados úteis?
* Pode reduzir?
* Pode filtrar?

---

## Passo 10 — Ajustar DCR (conceitual)

Abrir DCR:

* Remover eventos Info
* Manter Warning/Error
* Reduzir perf counters

---

# Parte 5 — Retenção de Dados

## Passo 11 — Configurar Retenção

Log Analytics → **Usage and estimated costs**

Retention:

* 30 dias (dev)
* 90 dias (prod)

Salvar.

---

# Parte 6 — Governance do Workspace

## Passo 12 — Naming e Tags

Workspace:

Adicionar tags:

* env: prod
* owner: ops
* costcenter: it

---

## Passo 13 — RBAC

Access control (IAM):

Verificar:

* Reader
* Contributor
* Monitoring roles

---

# Parte 7 — Estratégia Multi-Tool

Discussão orientada:

* Azure Monitor vs APM
* Logs onde?
* Alertas onde?
* Integração SIEM?

---

# Parte 8 — Avaliação Final (Mini Roadmap)

## Exercício

Definir para a organização:

* Workspace strategy
* Retenção
* DCR padrão
* Alertas globais
* Integrações
* Custos

---

# ✅ Resultados Esperados

Ao final do laboratório, o formando deverá:

* Integrar alertas ao Teams
* Explorar exportação de logs
* Analisar custos do workspace
* Identificar ingestão dominante
* Ajustar retenção
* Aplicar governance básico

---

# 🧠 Discussão Final

Perguntas orientadoras:

* Maior fonte de custo?
* Logs necessários vs excesso?
* Retenção ideal?
* Quem governa monitoramento?
* Multi-tool necessário?

---

# 🎓 Encerramento do Curso

Competências adquiridas:

* Azure Monitor
* Application Insights
* Observabilidade híbrida
* Containers
* Dados
* Alertas inteligentes
* KQL
* Workbooks
* Governance

---

> 🎉 Parabéns — trilha completa de Observabilidade com Azure Monitor concluída