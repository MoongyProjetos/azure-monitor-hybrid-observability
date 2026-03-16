# Plano de Formação

## Designação da Ação

**Azure Monitor para Ambientes Híbridos (Azure + On-Prem)**

---

## Enquadramento

A crescente adoção de arquiteturas híbridas, combinando infraestruturas on-premises, cloud pública e plataformas de containers, exige uma abordagem moderna de **observabilidade**, indo além da monitorização tradicional.

O Azure Monitor posiciona-se como a plataforma central da Microsoft para recolha, correlação e análise de métricas, logs e traces, incorporando capacidades de **automação e inteligência artificial** para deteção de anomalias, redução de ruído operacional e apoio à análise de causa raiz.

Esta ação de formação visa dotar os formandos de competências práticas para implementar e operar uma **estratégia de observabilidade moderna**, orientada a perfis (Application Owners, IT Ops / SRE), cobrindo ambientes Azure, infraestruturas híbridas, workloads em containers e integração com ferramentas líderes de mercado.

---

## Objetivos Gerais da Formação

No final da ação de formação, os formandos deverão ser capazes de:

* Implementar uma solução de observabilidade centralizada com Azure Monitor;
* Monitorar aplicações, bases de dados, containers e infraestruturas híbridas;
* Compreender a evolução dos agentes de monitorização e aplicar o Azure Monitor Agent (AMA);
* Utilizar capacidades de IA para deteção de anomalias e redução de alertas falsos;
* Criar alertas, dashboards e workbooks orientados a diferentes perfis organizacionais;
* Integrar notificações e automatizar respostas a incidentes;
* Integrar o Azure Monitor com outras plataformas de observabilidade;
* Definir políticas de governance e otimização de custos.

---

## Destinatários

* Profissionais de IT
* Administradores de sistemas
* Cloud Engineers
* DevOps Engineers
* Equipes de Operações e Suporte

---

## Pré‑requisitos

* Conhecimentos básicos de Azure
* Noções de sistemas operativos Windows e/ou Linux
* Familiaridade com conceitos de cloud computing

---

## Metodologia de Formação

A formação assenta numa **metodologia teórico‑prática**, com forte componente prática (hands‑on), privilegiando:

* Exposição dialogada de conceitos;
* Demonstrações técnicas pelo formador;
* Execução de exercícios práticos guiados;
* Resolução de cenários reais e problemas típicos de produção;
* Discussão e partilha de experiências.

---

## Metodologia de Avaliação

A avaliação será **contínua e formativa**, incidindo sobre:

* Participação ativa nas atividades propostas;
* Execução correta dos exercícios práticos;
* Cumprimento dos objetivos definidos para cada sessão;
* Avaliação prática final (plano ou artefactos criados).

---

## Estrutura da Formação

**Carga horária total:** 20 horas

**Formato:** 5 dias | 4 horas por dia (2 sessões de 2h)

---

## Programa da Formação

**Carga horária total:** 20 horas
**Formato:** 5 dias | 4 horas por dia (2 sessões de 2h, com pausa intermédia)

---

### Dia 1 — Fundamentos do Azure Monitor e Observabilidade Moderna (4h)

**Sessão 1 (2h)**

**Objetivo Geral:**
Compreender os fundamentos do Azure Monitor e os princípios da observabilidade moderna.

**Objetivos Específicos:**

* Identificar os principais componentes do Azure Monitor;
* Distinguir métricas, logs e dados de diagnóstico;
* Compreender o conceito de observabilidade e sua aplicação em ambientes empresariais.

**Conteúdos Programáticos:**

* Arquitetura do Azure Monitor
* Metrics vs Logs vs Diagnostics
* Log Analytics Workspace
* Conceito de Observabilidade Moderna

**Metodologia:**
Exposição dialogada com demonstrações práticas no Azure Portal.

**Avaliação:**
Questionamento oral orientado e exercício prático de classificação de sinais de monitorização.

---

**Sessão 2 (2h)**

**Objetivo Geral:**
Compreender a evolução dos agentes de monitorização e configurar a recolha moderna de dados.

**Objetivos Específicos:**

* Identificar as diferentes gerações de agentes de monitorização;
* Compreender o papel do Azure Monitor Agent (AMA);
* Criar e aplicar Data Collection Rules reutilizáveis.
* Compreender o funcionamento de alertas.

**Conteúdos Programáticos:**

* Evolução dos agentes (MMA, extensões de diagnóstico, AMA)
* Azure Monitor Agent
* Data Collection Rules (DCR)
* Boas práticas de arquitetura de recolha
* Introdução a Workbooks
* Alertas e fluxos operacionais

**Metodologia:**
Demonstração técnica seguida de exercício prático guiado.

**Avaliação:**
Criação de uma DCR funcional aplicada a múltiplos recursos com validação de ingestão de dados.

---

### Dia 2 — Observabilidade de Aplicações e Uso de IA (4h)

**Sessão 3 (2h)**

**Objetivo Geral:**
Monitorar aplicações Azure com foco na experiência do usuário e confiabilidade.

**Objetivos Específicos:**

* Ativar diagnósticos em App Services;
* Configurar Application Insights;
* Analisar métricas, logs e traces de aplicações.

**Conteúdos Programáticos:**

* App Services
* Métricas e logs de aplicação
* Application Insights
* Telemetria de aplicações

**Metodologia:**
Laboratório prático guiado com análise de cenários reais.

**Avaliação:**
Identificação de problemas de performance e fiabilidade numa aplicação monitorada.

---

**Sessão 4 (2h)**

**Objetivo Geral:**
Criar alertas eficazes para aplicações críticas e utilizar capacidades de inteligência artificial para deteção proativa de problemas.

**Objetivos Específicos:**

* Criar alertas baseados em métricas e logs;
* Criar queries KQL;
* Analisar dados de telemetria.
* Utilizar Smart Detection no Application Insights;
* Aplicar thresholds dinâmicos;
* Reduzir ruído operacional e falsos positivos.

**Conteúdos Programáticos:**

* Alertas de métricas
* Alertas baseados em logs
* Queries KQL
* Smart Detection
* Anomaly Detection
* Dynamic Thresholds
* Análise assistida de causa raiz

**Metodologia:**
Hands‑on com construção incremental de alertas
Hands-on com simulação de falhas e análise assistida por IA.

**Avaliação:**
Configuração de alertas inteligentes baseados em thresholds dinâmicos para um cenário definido.

---

### Dia 3 — Dados, Storage e Containers (4h)

**Sessão 5 (2h)**

**Objetivo Geral:**
Monitorar serviços de dados e armazenamento em Azure.

**Objetivos Específicos:**

* Analisar métricas DTU/vCore em Azure SQL;
* Utilizar Query Store e SQL Insights;
* Monitorar Storage Accounts.
* Configurar SQL Insights.

**Conteúdos Programáticos:**

* Azure SQL
* Query Store
* SQL Insights
* Storage Accounts
* Métricas e logs de storage

**Metodologia:**
Exercícios práticos com análise de métricas reais.

**Avaliação:**
Resolução de um problema de performance em Azure SQL ou Storage.

---

**Sessão 6 (2h)**

**Objetivo Geral:**
Monitorar workloads baseados em containers e Storage Accounts e garantir a sua disponibilidade.

**Objetivos Específicos:**

* Monitorizar latência e disponibilidade;
* Identificar situações de throttling;
* Criar dashboards operacionais.
* Monitorar clusters AKS;
* Analisar métricas e logs de containers;
* Monitorar ACI e ACR.

**Conteúdos Programáticos:**

* Storage Accounts
* Azure Kubernetes Service (AKS)
* Container Insights
* Azure Container Instances (ACI)
* Azure Container Registry (ACR)

**Metodologia:**
Laboratório prático com análise de falhas em workloads containerizados.

**Avaliação:**
Identificação e análise de problema num workload em AKS.

---

### Dia 4 — Infraestrutura Híbrida, Azure Arc e Estratégia de Agentes (4h)

**Sessão 7 (2h)**

**Objetivo Geral:**
Integrar e Monitorar infraestrutura híbrida.

**Objetivos Específicos:**

* Compreender o Azure Arc;
* Integrar servidores on-premises;
* Instalar o Azure Monitor Agent.
* Aplicar uma estratégia moderna de agentes.

**Conteúdos Programáticos:**

* Conceitos de Azure Arc
* Onboarding de servidores on-premises
* Azure Monitor Agent em ambientes híbridos

**Metodologia:**
Demonstração técnica e hands-on guiado.

**Avaliação:**
Servidor corretamente integrado ao Azure Arc.

---

**Sessão 8 (2h)**

**Objetivo Geral:**
Centralizar logs, métricas e alertas em ambientes híbridos.

**Objetivos Específicos:**

* Criar Data Collection Rules avançadas;
* Criar queries KQL para infraestrutura;
* Criar alertas de performance.

**Conteúdos Programáticos:**

* Data Collection Rules avançadas
* KQL para infraestrutura
* Alertas de performance

**Metodologia:**
Resolução de cenários práticos baseados em ambientes reais.

**Avaliação:**
Criação de alerta funcional para infraestrutura híbrida.

---

### Dia 5 — Dashboards por Perfil, Integrações e Governance (4h)

**Sessão 9 (2h)**

**Objetivo Geral:**
Criar visões operacionais orientadas a diferentes perfis organizacionais.

**Objetivos Específicos:**

* Criar dashboards e workbooks para Application Owners;
* Criar dashboards operacionais para IT Ops / SRE;
* Compartilhar e publicar dashboards.

**Conteúdos Programáticos:**

* Dashboards orientados a perfis
* Workbooks por persona
* Boas práticas de visualização

**Metodologia:**
Hands-on intensivo com criação de múltiplos workbooks.

**Avaliação:**
Criação de dois workbooks para perfis distintos.

---

**Sessão 10 (2h)**

**Objetivo Geral:**
Garantir sustentabilidade operacional através de integrações e governance.

**Objetivos Específicos:**

* Integrar Azure Monitor com outras plataformas de observabilidade;
* Controlar custos e ingestão de dados;
* Definir um plano de adoção de observabilidade.

**Conteúdos Programáticos:**

* Integração com ferramentas de observabilidade (ex.: Dynatrace, New Relic, Datadog)
* Estratégia multi-tool
* Governance e otimização de custos
* Roadmap de implementação

**Metodologia:**
Demonstração prática e exercício aplicado.

**Avaliação:**
Elaboração de um mini plano de observabilidade para a organização.



---

## Recursos Pedagógicos

* Azure Portal
* Laboratórios práticos
* Documentação oficial Microsoft
* Slides de apoio
