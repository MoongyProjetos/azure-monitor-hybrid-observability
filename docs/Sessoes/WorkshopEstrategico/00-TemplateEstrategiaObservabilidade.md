# 📘 Template — Estratégia de Observabilidade

## Empresa: __________________________

## Data: __________________________

## Facilitador: __________________________

---

# 1️⃣ Visão Geral e Objetivo

## 1.1 Objetivo da Estratégia

Definir um modelo padronizado de observabilidade para aplicações, infraestrutura, workloads em containers e ambientes híbridos, garantindo:

* Confiabilidade operacional
* Redução de ruído de alertas
* Detecção proativa de incidentes
* Visibilidade por perfil organizacional
* Sustentabilidade financeira

---

## 1.2 Escopo

☐ Aplicações Web
☐ APIs
☐ Azure SQL
☐ Storage
☐ AKS
☐ ACI
☐ ACR
☐ Máquinas Virtuais Azure
☐ Servidores On-Premises
☐ Outros: __________________

---

# 2️⃣ Arquitetura Padrão de Monitoramento

## 2.1 Plataforma Principal

Ferramenta central adotada:

☐ Azure Monitor
☐ Azure Monitor + Ferramenta Third-party
☐ Outra: __________________

---

## 2.2 Estratégia de Agentes

Padrão adotado:

☐ Azure Monitor Agent (AMA) como padrão único
☐ Modelo híbrido (especificar)
☐ Migração planejada de agentes legacy

Definições:

* DCR centralizadas: ☐ Sim ☐ Não
* Workspace único ou múltiplos: __________________
* Estratégia de retenção padrão: __________________

---

## 2.3 Modelo de Coleta de Dados

| Tipo de Sinal       | Obrigatório? | Observações |
| ------------------- | ------------ | ----------- |
| Métricas            | ☐ Sim ☐ Não  |             |
| Logs de Infra       | ☐ Sim ☐ Não  |             |
| Logs de Aplicação   | ☐ Sim ☐ Não  |             |
| Traces Distribuídos | ☐ Sim ☐ Não  |             |
| Logs de Containers  | ☐ Sim ☐ Não  |             |

---

# 3️⃣ Estratégia de Observabilidade de Aplicações

## 3.1 Application Insights

☐ Obrigatório para aplicações críticas
☐ Opcional
☐ Não aplicável

---

## 3.2 Telemetria Padrão

Aplicações devem registrar:

☐ Requests
☐ Exceptions
☐ Dependencies
☐ Custom Events
☐ Métricas de negócio

---

## 3.3 Uso de IA

☐ Smart Detection ativado
☐ Dynamic Thresholds adotado
☐ Alertas fixos mantidos

---

# 4️⃣ Estratégia de Alertas

## 4.1 Princípios

☐ Todo alerta deve ter responsável
☐ Alertas devem ser acionáveis
☐ Evitar alert fatigue
☐ Separação entre alerta e dashboard

---

## 4.2 Tipos de Alertas Permitidos

☐ Métricas
☐ Logs (KQL)
☐ Threshold dinâmico
☐ Baseado em anomalia

---

## 4.3 Fluxo Operacional

Alerta → __________________
Notificação via → __________________
Escalonamento → __________________
Criação automática de incidente? ☐ Sim ☐ Não

---

# 5️⃣ Containers e Workloads Modernos

## 5.1 AKS

☐ Container Insights obrigatório
☐ Logs centralizados
☐ Monitoramento de nós e pods

---

## 5.2 ACI

Estratégia definida: __________________

---

## 5.3 ACR

Monitoramento de:

☐ Pull failures
☐ Latência
☐ Segurança

---

# 6️⃣ Infraestrutura Híbrida

## 6.1 Azure Arc

☐ Servidores críticos integrados
☐ AMA padronizado
☐ DCR reutilizadas

---

## 6.2 Estratégia de Consolidação

Workspace único? __________________
Segmentação por ambiente? __________________

---

# 7️⃣ Dashboards por Perfil

## 7.1 Application Owners

Devem visualizar:

☐ SLA
☐ Taxa de erro
☐ Latência
☐ Disponibilidade

---

## 7.2 IT Ops / SRE

Devem visualizar:

☐ Saúde da infraestrutura
☐ Alertas ativos
☐ Capacidade
☐ Tendência de consumo

---

## 7.3 Gestão Executiva (Opcional)

☐ Visão consolidada
☐ Tendências
☐ Risco operacional

---

# 8️⃣ Estratégia Multi-Tool

Ferramentas adicionais em uso:

☐ Dynatrace
☐ Datadog
☐ New Relic
☐ Outra: __________________

Modelo adotado:

☐ Azure Monitor como fonte primária
☐ Ferramenta externa como principal
☐ Coexistência segmentada

---

# 9️⃣ Governance e Custos

## 9.1 Retenção Padrão

Dias de retenção: __________________

---

## 9.2 Tabelas Críticas

Tabelas com maior custo identificadas: __________________

---

## 9.3 Política de Diagnóstico

☐ Azure Policy aplicada
☐ Padronização obrigatória
☐ Tags para rastreabilidade

---

# 🔟 Roadmap de Implementação

## 10.1 Quick Wins (0–30 dias)

* ---
* ---

---

## 10.2 Médio Prazo (30–90 dias)

* ---
* ---

---

## 10.3 Longo Prazo

* ---
* ---

---

# ✅ Conclusão

A organização definiu um modelo estruturado de observabilidade com foco em:

* Padronização
* Inteligência operacional
* Redução de ruído
* Sustentabilidade financeira
* Evolução contínua

---

# 🎯 Como usar isso na prática

Durante a semana:

* Dia 1 → Preenche seção 1 e 2
* Dia 2 → Seção 3 e parte da 4
* Dia 3 → Seção 5
* Dia 4 → Seção 6
* Dia 5 → Seção 7, 8, 9 e 10