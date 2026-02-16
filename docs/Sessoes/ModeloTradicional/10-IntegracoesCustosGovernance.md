# 📘 Sessão 10 – Integrações, Custos e Governance

## 🎯 Objetivos da Sessão

* Integrar o Azure Monitor com ferramentas externas de observabilidade.
* Compreender estratégias multi-tool.
* Aplicar práticas de governance no Azure Monitor.
* Otimizar custos de ingestão e retenção de dados.
* Definir um roadmap de adoção de observabilidade.

---

## 🔗 Integrações do Azure Monitor

O Azure Monitor pode integrar com plataformas externas para:

* Observabilidade avançada
* APM complementar
* NOC/SOC
* ITSM
* Colaboração

Principais integrações:

* Dynatrace
* Datadog
* New Relic
* Microsoft Teams
* ITSM / Webhooks / Event Hub

---

## 📡 Integração com Ferramentas APM

Plataformas como Dynatrace, Datadog e New Relic podem:

* Coletar dados do Azure
* Ingerir logs e métricas
* Integrar alertas
* Correlacionar aplicações

Modelos de integração:

**Azure → ferramenta**
Exportação de dados

**Ferramenta → Azure**
Agente próprio + Azure

**Bidirecional**
Alertas e eventos

---

## 💬 Integração com Microsoft Teams

Alertas do Azure Monitor podem enviar notificações para Teams via:

* Action Groups
* Webhooks
* Logic Apps

Cenários:

* Canal de incidentes
* NOC
* War room
* On-call

Fluxo:

Azure Monitor Alert
→ Action Group
→ Teams

---

## 🧭 Estratégia Multi-Tool de Observabilidade

Ambientes corporativos frequentemente usam múltiplas ferramentas.

Exemplo:

* Azure Monitor → infraestrutura Azure
* Dynatrace → APM avançado
* SIEM → segurança
* ITSM → tickets

Princípios:

* Evitar duplicação
* Definir responsabilidade por domínio
* Centralizar logs críticos
* Correlacionar alertas

---

## 🏛️ Governance no Azure Monitor

Governance garante:

* Padronização
* Controle
* Segurança
* Custos previsíveis

Elementos principais:

* Naming padrão
* Workspaces centralizados
* DCR reutilizáveis
* Retenção definida
* RBAC
* Policy

---

## 💰 Custos no Azure Monitor

Custos principais:

* Ingestão de logs
* Retenção
* Métricas customizadas
* Queries frequentes
* Exportação

Modelo:

GB ingerido/dia

---

## 📉 Otimização de Custos

Boas práticas:

* Coletar apenas o necessário
* Filtrar eventos irrelevantes
* Ajustar retenção
* Usar DCR seletivas
* Arquivar dados antigos
* Separar dev/prod

Exemplos:

* Eventos Error em vez de Info
* Perf counters críticos
* Logs de apps essenciais

---

## 🗺️ Roadmap de Adoção de Observabilidade

Adoção madura ocorre em fases.

### Fase 1 — Fundamentos

* Workspace
* AMA
* Métricas básicas
* Logs centrais

---

### Fase 2 — Aplicações

* Application Insights
* Alertas
* Dashboards

---

### Fase 3 — Híbrido

* Azure Arc
* Infraestrutura completa
* KQL global

---

### Fase 4 — Avançado

* IA
* Automação
* Multi-tool
* SRE

---

## 🧠 Boas Práticas de Governança

* Workspace central por ambiente
* DCR por tipo de recurso
* Naming consistente
* Tags obrigatórias
* Retenção por criticidade
* Alertas padronizados

> 💡 Observabilidade madura depende mais de governança que de ferramenta.

---

## 🎓 Encerramento da Formação

Ao longo da formação, você desenvolveu competências em:

* Observabilidade moderna
* Azure Monitor
* Application Insights
* Infraestrutura híbrida
* Containers
* Dados
* Alertas inteligentes
* Workbooks e dashboards
* Governança

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Integrar Azure Monitor com outras plataformas.
* Definir estratégia multi-tool.
* Controlar custos de observabilidade.
* Aplicar governance.
* Planejar adoção organizacional.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor
