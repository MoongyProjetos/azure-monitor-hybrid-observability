# 🧪 Laboratório Hands-on 9 – Dashboards e Workbooks por Perfil

---

## 🎯 Objetivos do Laboratório

* Criar dashboards distintos por persona.
* Construir workbooks operacionais e estratégicos.
* Aplicar boas práticas de visualização.
* Definir modelo organizacional de visualização.
* Formalizar responsabilidade sobre indicadores.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A empresa já:

✔ Coleta dados
✔ Possui alertas
✔ Integra ambientes híbridos
✔ Monitorou aplicações, dados e containers

Agora precisa:

> Transformar dados em visibilidade clara por perfil.

---

# 🔎 Parte 0 — Diagnóstico Inicial (10 min)

Perguntar:

1. Existe dashboard único para tudo?
2. Application Owner usa o mesmo dashboard que Ops?
3. Dashboards são revisados periodicamente?
4. Dashboard substitui alerta?
5. Existe visão executiva consolidada?

Registrar respostas.

---

# Parte 1 — Criar Workbook para Application Owner

---

## 🎯 Objetivo

Responder:

* A aplicação está saudável?
* Usuário está sendo impactado?
* SLA está sendo cumprido?

---

## Passo 1 — Criar Workbook

Azure Monitor → Workbooks → Create

Adicionar visualizações:

1. Taxa de erro (requests com 5xx)
2. Latência média
3. Disponibilidade
4. Volume de requisições
5. Mapa de dependências (se aplicável)

---

## Query exemplo

```kql
requests
| summarize ErrorRate = 100.0 * countif(success == false) / count() by bin(timestamp, 5m)
| render timechart
```

---

## 🧠 Discussão

Perguntar:

* Esse dashboard permite decisão rápida?
* Está técnico demais?
* Está orientado a impacto?

---

# Parte 2 — Criar Workbook para IT Ops / SRE

---

## 🎯 Objetivo

Responder:

* Infra está saudável?
* Existe risco de capacidade?
* Existe alerta ativo?
* Algum agente parou?

---

## Adicionar visualizações:

1. CPU média por VM
2. Uso de memória
3. Restart de pods AKS
4. Servidores sem heartbeat
5. Alertas ativos

---

## Query exemplo – Heartbeat

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

---

## Query exemplo – Restart de Pod

```kql
KubePodInventory
| summarize Restarts = max(ContainerRestartCount) by PodName
| order by Restarts desc
```

---

## 🧠 Discussão

Perguntar:

* Ops precisa ver latência de aplicação?
* Application Owner precisa ver CPU?
* Há sobreposição desnecessária?

---

# Parte 3 — Boas Práticas de Visualização

Apresentar princípios:

### 1️⃣ Hierarquia visual clara

Crítico → Alto → Médio → Informativo

### 2️⃣ Não misturar níveis

App ≠ Infra ≠ Executivo

### 3️⃣ Evitar poluição visual

Menos gráficos, mais clareza.

### 4️⃣ Nomeação padronizada

Exemplo:

* WB-APP-Prod-Health
* WB-Ops-Infra-Overview

### 5️⃣ Filtros por ambiente

Dev ≠ Prod

---

# Parte 4 — Dashboard Executivo (Opcional)

Criar visão simplificada:

* Disponibilidade consolidada
* Tendência de incidentes
* Tendência de erro
* Capacidade geral

Pergunta:

> Diretoria precisa ver CPU ou disponibilidade?

---

# 🧠 Momento Estratégico

Preencher com grupo:

✔ Dashboard por persona definido
✔ Dono de cada dashboard
✔ Periodicidade de revisão
✔ Separação App vs Infra
✔ Ambiente separado

---

# 🧠 Perguntas de Maturidade

1. Dashboard substitui alerta?
2. Dashboard ajuda a prevenir incidente?
3. Existe KPI oficial?
4. Há indicadores de negócio?

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Dois workbooks criados (App Owner + Ops).
* Separação clara de responsabilidades.
* Modelo de visualização formalizado.
* Governança visual iniciada.
* Organização começa a enxergar observabilidade como processo.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

Dados disponíveis
em
Visibilidade orientada a responsabilidade.
