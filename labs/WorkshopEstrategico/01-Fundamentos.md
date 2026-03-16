# 🧪 Laboratório Hands-on 1 – Fundamentos e Diagnóstico de Observabilidade: Entender sinais + mapear maturidade

## 🎯 Objetivos do Laboratório

* Criar um Log Analytics Workspace.
* Explorar métricas e logs de um recurso Azure.
* Executar consultas KQL básicas.
* Correlacionar métricas e logs.
* Avaliar o modelo atual de monitoramento da empresa.
* Iniciar definição da arquitetura de observabilidade.

---

## ⏱️ Duração Estimada

75–90 minutos

---

## 📋 Cenário Estratégico

A organização deseja estruturar uma estratégia moderna de observabilidade.

Antes de definir padrões, precisamos:

* Entender o modelo atual
* Criar base técnica mínima
* Visualizar dados reais
* Identificar lacunas

Este laboratório servirá como:

> Base prática + diagnóstico inicial.

---

# 🔎 Parte 0 — Diagnóstico Inicial (Workshop – 20 min)

Antes de criar qualquer recurso, responda em grupo:

1. Hoje vocês possuem Log Analytics Workspace?
2. Workspace único ou múltiplos?
3. Quem é dono do monitoramento?
4. Existe padrão de coleta?
5. Já utilizam Application Insights?
6. Existem alertas ativos?
7. Sabem o custo mensal de ingestão?

📌 Registrar respostas no quadro.

Isso alimentará o documento estratégico.

---

# Parte 1 — Criar Log Analytics Workspace

## Passo 1 — Criar o Workspace

1. Acessar o Azure Portal
2. Procurar **Log Analytics workspaces**
3. Selecionar **Create**

Configuração sugerida:

* Resource Group: rg-observability-workshop
* Name: law-obs-workshop
* Região: mesma dos workloads

👉 Criar

---

## 🔎 Discussão Estratégica

Pergunta ao grupo:

> A organização deve ter:
>
> * Um único workspace global?
> * Um por ambiente (dev/hml/prod)?
> * Um por domínio (infra/apps)?

Anotar decisão preliminar.

---

# Parte 2 — Ativar Coleta via Diagnostic Settings

Escolher um recurso existente:

* App Service
* Storage Account
* VM

---

## Passo 2 — Ativar Diagnostic Settings

1. Abrir recurso
2. Monitoring → Diagnostic settings
3. Add diagnostic setting

Configuração:

* Enviar logs
* Enviar métricas
* Destination → Log Analytics Workspace criado

👉 Save

---

## 🔎 Discussão Estratégica

Perguntar:

* Todo recurso deve ter diagnostic settings obrigatório?
* Deve existir Azure Policy para forçar isso?
* Quais categorias de log são realmente necessárias?

---

# Parte 3 — Explorar Métricas

## Passo 3 — Abrir Métricas

Monitoring → Metrics

Selecionar métricas relevantes do recurso.

Exemplos:

App Service:

* Requests
* Average Response Time
* HTTP 5xx

Storage:

* Transactions
* Availability
* Latency

---

## 🧠 Exercício Analítico

Responder:

1. Métrica com maior variação?
2. Existe pico?
3. Métrica isolada permite entender causa raiz?

Provocar reflexão:

> Métrica diz “o quê”.
> Log explica “por quê”.

---

# Parte 4 — Consultar Logs (KQL)

Abrir:

Log Analytics Workspace → Logs

---

## Query 1 — AzureActivity

```kql
AzureActivity
| take 50
```

Pergunta:

* Houve alteração recente em recurso crítico?

---

## Query 2 — Heartbeat

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
```

Pergunta:

* Existem máquinas que pararam de enviar dados?

---

## Query 3 — InsightsMetrics

```kql
InsightsMetrics
| take 50
```

Objetivo:

Visualizar métricas como logs.

---

# Parte 5 — Correlação Estratégica

Executar:

```kql
AzureActivity
| where TimeGenerated > ago(1h)
| summarize count() by bin(TimeGenerated, 5m)
| render timechart
```

Perguntas:

* Alterações coincidem com picos?
* Há evidência de deploy recente?
* É possível correlacionar evento e comportamento?

---

# 🧠 Momento Estratégico (Muito Importante)

Perguntas finais:

1. Hoje vocês conseguiriam investigar um incidente real usando apenas o que vimos?
2. Falta padronização?
3. Falta telemetria?
4. Falta alerta?
5. Falta governança?

---

# 📌 Registro para Documento Estratégico

Preencher junto com o grupo:

* Workspace recomendado
* Modelo preliminar de coleta
* Lacunas identificadas
* Riscos atuais

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Workspace funcional criado
* Recurso enviando logs
* Queries KQL executadas
* Diferença prática entre métricas e logs compreendida
* Lacunas organizacionais identificadas
* Primeiras decisões arquiteturais iniciadas

---

# 🚀 Extensão Opcional

Criar gráfico:

```kql
AzureActivity
| summarize count() by bin(TimeGenerated, 5m)
| render timechart
```

Depois perguntar:

> Isso é suficiente para alertar automaticamente?

---

# 🎯 O que mudou em relação ao modelo antigo?

Antes:
Aprender Azure Monitor.

Agora:
Usar Azure Monitor para diagnosticar maturidade da empresa.
