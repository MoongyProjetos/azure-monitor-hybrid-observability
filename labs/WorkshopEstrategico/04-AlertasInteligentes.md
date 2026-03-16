# 🧪 Laboratório Hands-on 4 – Alertas Inteligentes e Análise com IA : Como detectar problema antes do usuário abrir chamado?

---

## 🎯 Objetivos do Laboratório

* Criar alertas baseados em métricas e logs.
* Desenvolver consultas KQL operacionais.
* Configurar Dynamic Thresholds.
* Explorar Smart Detection no Application Insights.
* Realizar análise assistida de causa raiz.
* Definir modelo organizacional de alertas.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A empresa já coleta dados e monitora aplicações.

Porém:

* Existem alertas demais.
* Existem alertas irrelevantes.
* Nem sempre alertas indicam impacto real.

O objetivo agora é:

> Criar alertas inteligentes, acionáveis e com governança.

---

# 🔎 Parte 0 — Diagnóstico de Maturidade (10 min)

Perguntas ao grupo:

1. Vocês sofrem com alert fatigue?
2. Quantos alertas são ignorados?
3. Existe revisão periódica de alertas?
4. Alertas estão ligados a SLA?
5. Todo alerta tem responsável?

Registrar respostas.

---

# Parte 1 — Criar Alerta Baseado em Métrica

## Cenário

Aplicação com erro acima de 5% por 5 minutos.

---

## Passo 1 — Criar Alert Rule

1. App Service ou Application Insights
2. Alerts → Create alert rule
3. Condition → Failed Requests (%)
4. Threshold → 5%
5. Aggregation → 5 minutos
6. Severity → 2 (Warning)

Criar ou reutilizar Action Group.

---

## 🧠 Reflexão

Perguntar:

> Esse alerta é realmente acionável?

---

# Parte 2 — Criar Alerta Baseado em KQL

Agora vamos subir nível.

## Cenário

Detectar exceções críticas específicas.

---

## Query exemplo

```kql
exceptions
| where type == "System.NullReferenceException"
| summarize count() by bin(timestamp, 5m)
```

Criar alerta baseado nessa query.

---

## Discussão Estratégica

Perguntar:

* Qual é mais poderoso?
* Métrica simples ou log customizado?
* Quem escreve as queries oficiais?

---

# Parte 3 — Dynamic Thresholds

Criar novo alerta de métrica.

Selecionar:

→ Dynamic Threshold

Comparar com threshold fixo.

---

## Exercício

Observar gráfico:

* O sistema aprende padrão?
* Detecta comportamento anômalo?

Pergunta:

> Threshold fixo faz sentido para todos os workloads?

---

# Parte 4 — Smart Detection (IA)

Abrir:

Application Insights → Investigate → Smart Detection

Explorar:

* Performance degradation
* Failure anomaly
* Dependency slowdown

---

## 🧠 Discussão Estratégica

Perguntar:

1. Vocês preferem criar dezenas de regras manuais?
2. Confiam em detecção automática?
3. Smart Detection deve estar habilitado por padrão?

---

# Parte 5 — Análise Assistida de Causa Raiz

Simular cenário:

Usuário reclama de lentidão.

Fluxo:

1. Ver latência média.
2. Identificar request lenta.
3. Ver dependência lenta.
4. Ver exceção.
5. Correlacionar com deploy (AzureActivity).

Demonstrar:

* Application Map
* Correlation ID
* Query cruzada

---

# 🧠 Classificação Organizacional de Alertas

Introduzir modelo:

🔴 Crítico – Impacto direto no usuário
🟠 Alto – Degradação significativa
🟡 Médio – Atenção
🔵 Informativo – Apenas dashboard

Perguntar:

> Vamos formalizar isso?

Registrar decisão.

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ Alertas baseados em impacto
✔ Dynamic Threshold como padrão quando possível
✔ Smart Detection ativado
✔ Revisão trimestral de alertas
✔ Action Group padronizado

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Alertas inteligentes criados.
* Diferença entre métrica e KQL compreendida.
* Dynamic Threshold testado.
* Smart Detection explorado.
* Modelo organizacional de alertas iniciado.

---

# 🚀 Extensão Opcional

Criar alerta para:

Servidor que parou de enviar logs:

```kql
Heartbeat
| where TimeGenerated < ago(10m)
```

Perguntar:

> Isso é mais crítico que CPU alta?

Provocar maturidade.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

Alertas reativos
em
Detecção inteligente com governança.

