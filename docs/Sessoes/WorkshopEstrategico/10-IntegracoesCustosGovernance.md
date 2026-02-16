# 📘 Sessão 10 – Integrações, Custos e Governance

---

## 🎯 Objetivos da Sessão

* Avaliar integração do Azure Monitor com outras ferramentas.
* Definir estratégia multi-tool (quando aplicável).
* Compreender modelo de custos do Log Analytics.
* Estabelecer diretrizes de governança.
* Construir roadmap prático de adoção.
* Consolidar decisões estratégicas da semana.

---

# 🔗 Parte 1 – Integração com Outras Ferramentas

Empresas raramente têm ferramenta única.

Ferramentas comuns:

* Dynatrace
* Datadog
* New Relic
* Microsoft Teams

---

## 🧠 Pergunta Estratégica

> Azure Monitor será a ferramenta primária ou complementar?

---

## 🔄 Modelos Possíveis

### Modelo 1 – Azure Monitor como Fonte Primária

Azure Monitor coleta tudo.
Ferramenta externa consome ou complementa.

✔ Melhor integração com Azure
✔ Menor duplicidade de coleta

---

### Modelo 2 – Ferramenta Third-Party como Primária

Azure Monitor apenas para recursos nativos.

⚠ Pode gerar duplicidade
⚠ Maior custo

---

### Modelo 3 – Coexistência Segmentada

Exemplo:

* Azure Monitor → Infra e PaaS
* Datadog → Aplicações específicas

Exige governança forte.

---

## 🔔 Integração Operacional

Alertas podem integrar com:

* Microsoft Teams
* ITSM
* Webhooks
* Logic Apps

Pergunta-chave:

> Todo alerta gera ticket ou só os críticos?

---

# 💰 Parte 2 – Custos do Log Analytics

Aqui você entra no ponto sensível.

## O que gera custo?

* Volume de ingestão (GB/dia)
* Retenção
* Tabelas de alto volume
* Logs desnecessários

---

## Estratégias de Otimização

* Coletar apenas o necessário
* Usar DCR com critério
* Ajustar retenção por criticidade
* Identificar tabelas mais caras
* Usar métricas quando possível (mais barato que log)

Pergunta estratégica:

> Vocês sabem hoje quanto custa a ingestão mensal?

Se não sabem, há risco de governança.

---

# 🏛️ Parte 3 – Governance

Governança de observabilidade inclui:

* Padrão de agente (AMA)
* Padrão de DCR
* Padrão de alertas
* Padrão de dashboard
* Política de retenção
* Responsáveis definidos

---

## Mini-Checklist de Governança

☐ AMA é padrão único
☐ Workspace definido estrategicamente
☐ Alertas têm dono
☐ DCR padronizadas
☐ Dashboard por perfil definido
☐ Política de retenção documentada

---

# 🛣️ Parte 4 – Roadmap de Adoção

Aqui você fecha como consultor.

Divida em:

---

## 🔹 Quick Wins (0–30 dias)

Exemplos:

* Padronizar AMA
* Criar 3 DCR padrão
* Criar dashboard Application Owner
* Revisar alertas críticos

---

## 🔹 Médio Prazo (30–90 dias)

* Revisão de ingestão
* Otimização de custo
* Padronização de telemetria
* Integração com ITSM

---

## 🔹 Longo Prazo

* Maturidade em SLO
* Observabilidade orientada a negócio
* Automação de resposta a incidentes
* Melhoria contínua

---

# 🧠 Encerramento Estratégico

Você pode fechar com:

> Observabilidade não é ferramenta.
> É arquitetura, processo e cultura.

E depois perguntar:

> O que começa amanhã?

Essa pergunta muda comportamento.

---

# 🎯 Resultado Esperado da Sessão 10

Ao final da formação:

* A empresa tem arquitetura definida.
* Existe padrão de agente.
* Existe modelo de alertas.
* Existe modelo de dashboard.
* Existe estratégia de integração.
* Existe roadmap claro.