# 🧪 Laboratório Hands-on 7 – Infraestrutura Híbrida e Azure Arc : Como unificar tudo isso quando parte da infraestrutura está fora do Azure?

---

## 🎯 Objetivos do Laboratório

* Compreender o papel do Azure Arc na estratégia híbrida.
* Integrar um servidor on-premises ao Azure.
* Aplicar Azure Monitor Agent via Arc.
* Associar Data Collection Rules em ambiente híbrido.
* Definir padrão organizacional unificado de agentes.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização possui:

* Recursos no Azure
* Servidores on-premises
* Possivelmente ferramentas distintas para cada ambiente

Problemas comuns:

* Monitoramento fragmentado
* Agentes diferentes
* Workspace diferentes
* Falta de governança

Objetivo:

> Unificar observabilidade entre cloud e on-prem.

---

# 🔎 Parte 0 — Diagnóstico Inicial (10–15 min)

Perguntas ao grupo:

1. On-prem é monitorado com qual ferramenta?
2. Existe visibilidade consolidada?
3. Há duplicidade de custo?
4. Há padrão único de agente?
5. Há servidores críticos fora do Azure?

Registrar respostas.

---

# Parte 1 — Conceito Prático de Azure Arc

Explicar visualmente:

Servidor físico / VM on-prem
↓
Azure Arc
↓
Recurso gerenciado no Azure

Pergunta estratégica:

> Todo servidor deve estar sob governança central?

---

# Parte 2 — Onboarding de Servidor (Simulado ou Real)

Se houver ambiente:

1. Azure Portal → Azure Arc → Servers
2. Add
3. Gerar script de onboarding
4. Executar script na máquina (Windows/Linux)
5. Confirmar registro no Azure

Se não houver:

* Demonstração guiada
* Análise de arquitetura

---

# Parte 3 — Aplicar Azure Monitor Agent via Arc

Após servidor aparecer como recurso Arc:

1. Extensions → Add
2. Azure Monitor Agent
3. Instalar

---

## Associar DCR Existente

Usar DCR criada na Sessão 2.

Perguntar:

> Mesma DCR serve para cloud e on-prem?

Provocar padronização.

---

# Parte 4 — Validar Ingestão Híbrida

Abrir Log Analytics → Logs

Query:

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
```

Confirmar:

* VM Azure
* Servidor On-Prem
  Ambos enviando dados.

Isso é momento-chave.

---

# 🧠 Discussão Estratégica

Perguntas importantes:

1. Vamos padronizar AMA como único agente?
2. Vamos migrar agentes legados?
3. Workspace único ou segmentado?
4. Servidores críticos terão DCR diferenciada?
5. Retenção será igual para cloud e on-prem?

Registrar decisões.

---

# Parte 5 — Estratégia Moderna de Agentes

Apresentar modelo recomendado:

```
Cloud VMs → AMA
On-Prem → Arc + AMA
Containers → Container Insights
Apps → Application Insights
```

Perguntar:

> Queremos dois modelos de coleta ou um modelo único?

Resposta madura: único.

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ AMA padrão único
✔ Arc obrigatório para servidores críticos
✔ DCR reutilizadas
✔ Workspace definido
✔ Governança formalizada

---

# 🧠 Discussão Final

Perguntas de maturidade:

1. Hoje existe diferença entre monitoramento cloud e on-prem?
2. Existe duplicidade de ferramenta?
3. Há oportunidade de consolidação?
4. Há redução potencial de custo?

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Servidor híbrido integrado (real ou conceitualmente).
* AMA aplicado via Arc.
* DCR reutilizada.
* Ingestão híbrida validada.
* Modelo unificado desenhado.

---

# 🚀 Extensão Opcional

Criar alerta:

Servidor on-prem sem heartbeat por 10 minutos.

Perguntar:

> Isso é mais crítico que CPU alta?

Provocar reflexão sobre impacto real.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

Monitoramento fragmentado
em
Arquitetura híbrida unificada.
