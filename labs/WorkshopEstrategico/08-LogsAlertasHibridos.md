# 🧪 Laboratório Hands-on 8 – Logs e Alertas em Ambientes Híbridos : Como garantir que isso escala, é auditável e não vira bagunça daqui a 6 meses?

---

## 🎯 Objetivos do Laboratório

* Criar Data Collection Rules (DCR) avançadas reutilizáveis.
* Desenvolver consultas KQL operacionais para infraestrutura.
* Criar alertas de performance em ambiente híbrido.
* Validar centralização de métricas e logs.
* Formalizar modelo organizacional de governança de coleta.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A empresa já:

✔ Usa AMA
✔ Integra Azure e On-Prem via Arc
✔ Coleta logs e métricas

Agora precisa:

* Garantir padrão mínimo obrigatório
* Evitar ingestão descontrolada
* Criar alertas com foco em impacto
* Consolidar dados em modelo sustentável

---

# 🔎 Parte 0 — Diagnóstico Inicial (10 min)

Perguntar:

1. Cada servidor coleta logs diferentes?
2. Existe DCR padronizada?
3. Já houve crescimento inesperado de ingestão?
4. Existe alerta para falha de agente?
5. Workspace está centralizado?

Registrar respostas.

---

# Parte 1 — Criar DCR Avançada

## Cenário

Criar DCR padrão “Servidor Crítico”.

---

## Passo 1 — Criar Nova DCR

Nome sugerido:

```
dcr-critical-infra
```

Adicionar:

* Performance counters (CPU, memória, disco)
* Event Logs críticos
* Frequência ajustada (não granular demais)

---

## Associar a múltiplos recursos

Selecionar:

* VM Azure
* Servidor Arc

Aplicar mesma DCR.

---

## 🧠 Discussão Estratégica

Perguntar:

1. Devemos ter:

   * DCR mínima obrigatória?
   * DCR por perfil?
   * DCR por ambiente?
2. Quem aprova alteração de DCR?
3. DCR deve ser controlada via IaC?

Esse é momento de governança real.

---

# Parte 2 — KQL Operacional para Infraestrutura

Aqui você ensina queries que resolvem problema real.

---

## 🔹 Query – Servidores com CPU Alta

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by Computer, bin(TimeGenerated, 5m)
| where avg_CounterValue > 80
```

---

## 🔹 Query – Servidor Sem Heartbeat

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

---

## 🔹 Query – Reboots Recentes

```kql
Event
| where EventLevelName == "Information"
| where EventID == 6005
| where TimeGenerated > ago(24h)
```

---

## 🧠 Pergunta Estratégica

> Quais dessas situações merecem alerta automático?

Aqui você começa a diferenciar:

* Sintoma
* Impacto
* Ruído

---

# Parte 3 — Criar Alertas de Performance

Criar:

1. Alerta CPU alta (métrica)
2. Alerta “Sem Heartbeat” (KQL)
3. Definir severidade

Perguntar:

> Qual é mais crítico:
> CPU alta ou servidor offline?

Isso eleva maturidade.

---

# Parte 4 — Validar Centralização de Dados

Executar query para visualizar todos os tipos de origem:

```kql
Heartbeat
| summarize count() by Computer
```

Confirmar que aparecem:

* VM Azure
* Servidor Arc

Depois:

```kql
AzureActivity
| summarize count() by ResourceProvider
```

Perguntar:

> Temos visão consolidada ou fragmentada?

---

# Parte 5 — Estratégia de Centralização

Discussão guiada:

1. Workspace único global?
2. Workspace por ambiente?
3. Workspace por domínio?
4. Retenção única?
5. Tabelas mais caras identificadas?

Introduzir:

* Redução de ingestão
* Retenção diferenciada
* Uso de métricas quando possível

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ DCR padrão organizacional definida
✔ Critérios de criação de novas DCR
✔ Alertas críticos formalizados
✔ Severidade padronizada
✔ Estratégia de workspace definida

---

# 🧠 Discussão Final

Perguntas de maturidade:

1. Hoje a organização consegue auditar o que coleta?
2. Existe controle sobre custo de ingestão?
3. Existe padrão mínimo por tipo de servidor?
4. Alertas estão ligados a responsabilidade clara?

---

# ✅ Resultados Esperados

Ao final do laboratório:

* DCR avançada criada e aplicada.
* Queries operacionais dominadas.
* Alertas híbridos criados.
* Ingestão validada.
* Modelo de centralização definido.
* Governança começa a ganhar forma concreta.

---

# 🚀 Extensão Opcional

Criar gráfico KQL:

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by bin(TimeGenerated, 5m)
| render timechart
```

Perguntar:

> Isso é suficiente para prever problema ou só reagir?

Provocar visão preditiva.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

Monitoramento híbrido funcional
em
Monitoramento híbrido governável e sustentável.

