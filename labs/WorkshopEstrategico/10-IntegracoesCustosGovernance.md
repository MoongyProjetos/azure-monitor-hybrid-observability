# 🧪 Laboratório Hands-on 10 – Integrações, Custos e Governance

---

## 🎯 Objetivos do Laboratório

* Avaliar modelo de integração com outras ferramentas de observabilidade.
* Definir estratégia multi-tool (quando aplicável).
* Analisar impacto de ingestão e retenção no custo.
* Formalizar modelo de governança.
* Construir roadmap prático de adoção.
* Consolidar decisões estratégicas da semana.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização já:

✔ Padronizou agentes
✔ Definiu DCR
✔ Criou alertas
✔ Estruturou dashboards
✔ Integra ambiente híbrido

Agora precisa responder:

> Como sustentar isso com governança, custo controlado e integração adequada?

---

# 🔎 Parte 1 — Integração com Outras Ferramentas

Ferramentas comuns no mercado:

* Dynatrace
* Datadog
* New Relic
* Microsoft Teams

---

## 🧠 Exercício Estratégico

Dividir o grupo:

Responder:

1. Azure Monitor será primário ou complementar?
2. Existe duplicidade de coleta?
3. Existe sobreposição de alertas?
4. Existe integração com ITSM?

---

## 🔄 Modelos Possíveis

### Modelo A – Azure Monitor como Primário

✔ Melhor integração nativa
✔ Menor duplicidade

---

### Modelo B – Third-Party como Primário

⚠ Pode gerar custo duplicado
⚠ Pode gerar conflitos de governança

---

### Modelo C – Segmentação por domínio

Exemplo:

* Azure Monitor → Infra
* Datadog → Aplicações

Exige padrão muito claro.

---

# Parte 2 — Integração Operacional (Hands-on)

Criar ou revisar Action Group:

* Enviar alerta para Teams
* Simular notificação

Pergunta:

> Todo alerta gera ticket?

Definir política.

---

# 💰 Parte 3 — Análise de Custos

Abrir:

Log Analytics Workspace → Usage and estimated costs

---

## Identificar:

* Ingestão diária
* Tabelas com maior volume
* Retenção atual

---

## 🧠 Discussão

Perguntas:

1. Todas as tabelas são necessárias?
2. Retenção está alinhada à criticidade?
3. Logs podem virar métricas?
4. DCR pode ser otimizada?

---

# 🛠️ Exercício – Otimização Conceitual

Propor cenário:

* Reduzir retenção de 180 → 30 dias para logs não críticos
* Manter 180 para banco crítico

Perguntar:

> Isso impacta governança ou apenas custo?

---

# 🏛️ Parte 4 — Governança Formal

Construir checklist final:

✔ AMA padrão único
✔ DCR padronizadas
✔ Alertas com severidade formal
✔ Dashboard por persona
✔ Workspace definido
✔ Política de retenção documentada
✔ Revisão trimestral de alertas
✔ Donos definidos

---

# 🛣️ Parte 5 — Roadmap de Adoção

Dividir quadro em 3 fases:

---

## 🔹 0–30 dias (Quick Wins)

* Padronizar AMA
* Criar DCR mínima
* Formalizar severidade de alertas
* Criar dashboards principais

---

## 🔹 30–90 dias

* Revisar ingestão
* Ajustar retenção
* Integrar ITSM
* Padronizar telemetria de aplicação

---

## 🔹 90+ dias

* Introduzir SLO formal
* Observabilidade orientada a negócio
* Automação de resposta
* Revisão de maturidade

---

# 🧠 Momento Final – Consolidação

Perguntar ao grupo:

1. O que começa amanhã?
2. Quem é responsável?
3. O que depende de decisão executiva?
4. Onde há maior risco atual?

Registrar compromissos.

---

# 🎯 Encerramento Estratégico (fala forte)

Você pode fechar assim:

> Observabilidade não é ferramenta.
> É arquitetura + processo + cultura.
>
> Se ela não for governada, vira custo.
> Se for bem implementada, vira vantagem competitiva.

---

# ✅ Resultado Esperado

Ao final do laboratório:

* Estratégia multi-tool definida (ou rejeitada).
* Modelo de custo compreendido.
* Governança formalizada.
* Roadmap prático estabelecido.
* Workshop encerrado com direção clara.
