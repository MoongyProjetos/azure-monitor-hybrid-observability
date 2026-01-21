# Plano de Formação

## Designação da Ação

**Azure Monitor para Ambientes Híbridos (Azure + On-Prem)**

---

## Enquadramento

A crescente adoção de arquiteturas híbridas, combinando infraestruturas on‑premises com serviços cloud, exige uma abordagem integrada de monitorização, observabilidade e resposta a incidentes. O Azure Monitor apresenta‑se como a solução central da Microsoft para recolha, análise e atuação sobre métricas, logs e eventos, permitindo garantir disponibilidade, performance, segurança e controlo de custos.

Esta ação de formação visa dotar os formandos de competências práticas para implementar e operar o Azure Monitor em ambientes híbridos empresariais, recorrendo a boas práticas amplamente adotadas no mercado.

---

## Objetivos Gerais da Formação

No final da ação de formação, os formandos deverão ser capazes de:

* Implementar uma solução de monitorização centralizada com Azure Monitor;
* Monitorizar aplicações, bases de dados, serviços de armazenamento e servidores on‑prem;
* Criar alertas, dashboards e workbooks operacionais;
* Integrar notificações e automatizar respostas a incidentes;
* Definir políticas de governance e otimização de custos.

---

## Destinatários

* Profissionais de IT
* Administradores de sistemas
* Cloud Engineers
* DevOps Engineers
* Equipas de Operações e Suporte

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

### Dia 1 — Fundamentos do Azure Monitor (4h)

**Sessão 1 (2h)**

**Objetivo Geral:**
Compreender a arquitetura e os conceitos fundamentais do Azure Monitor.

**Objetivos Específicos:**

* Identificar os principais componentes do Azure Monitor;
* Distinguir métricas, logs e dados de diagnóstico;
* Compreender o fluxo de dados numa arquitetura de monitorização.

**Conteúdos Programáticos:**

* Arquitetura do Azure Monitor
* Metrics vs Logs vs Diagnostics
* Log Analytics Workspace

**Metodologia:**
Exposição dialogada com demonstrações no Azure Portal.

**Avaliação:**
Questionamento oral e exercício de identificação do tipo de dado mais adequado para diferentes cenários.

---

**Sessão 2 (2h)**

**Objetivo Geral:**
Configurar a recolha de dados e compreender como gerar insights operacionais.

**Objetivos Específicos:**

* Criar e aplicar Data Collection Rules (DCR);
* Utilizar Insights e Workbooks;
* Compreender o funcionamento de alertas.

**Conteúdos Programáticos:**

* Data Collection Rules
* Azure Monitor Insights
* Introdução a Workbooks
* Alertas e fluxos operacionais

**Metodologia:**
Demonstração prática seguida de exercício hands‑on.

**Avaliação:**
Criação de uma DCR funcional com validação de ingestão de dados.

---

### Dia 2 — Monitorização de Aplicações Azure (4h)

**Sessão 3 (2h)**

**Objetivo Geral:**
Monitorizar aplicações Azure utilizando Application Insights.

**Objetivos Específicos:**

* Ativar diagnósticos em App Services;
* Configurar Application Insights;
* Analisar métricas e telemetria de aplicações.

**Conteúdos Programáticos:**

* App Services
* Métricas e logs de aplicação
* Application Insights

**Metodologia:**
Laboratório prático guiado.

**Avaliação:**
Identificação de problemas de performance numa aplicação monitorizada.

---

**Sessão 4 (2h)**

**Objetivo Geral:**
Criar alertas eficazes para aplicações críticas.

**Objetivos Específicos:**

* Criar alertas baseados em métricas e logs;
* Criar queries KQL;
* Analisar dados de telemetria.

**Conteúdos Programáticos:**

* Alertas de métricas
* Alertas baseados em logs
* Queries KQL

**Metodologia:**
Hands‑on com construção incremental de alertas.

**Avaliação:**
Criação de um alerta funcional para um cenário definido.

---

### Dia 3 — Azure SQL e Storage Accounts (4h)

**Sessão 5 (2h)**

**Objetivo Geral:**
Monitorizar bases de dados Azure SQL.

**Objetivos Específicos:**

* Analisar métricas DTU/vCore;
* Utilizar Query Store;
* Configurar SQL Insights.

**Metodologia:**
Exercícios práticos e análise de métricas reais.

**Avaliação:**
Resolução de um problema de performance em Azure SQL.

---

**Sessão 6 (2h)**

**Objetivo Geral:**
Monitorizar Storage Accounts e garantir a sua disponibilidade.

**Objetivos Específicos:**

* Monitorizar latência e disponibilidade;
* Identificar situações de throttling;
* Criar dashboards operacionais.

**Metodologia:**
Laboratório prático.

**Avaliação:**
Criação de um dashboard funcional de Storage.

---

### Dia 4 — Infraestrutura On‑Prem com Azure Arc (4h)

**Sessão 7 (2h)**

**Objetivo Geral:**
Integrar servidores on‑premises no Azure Monitor.

**Objetivos Específicos:**

* Compreender o Azure Arc;
* Efetuar onboarding de servidores;
* Instalar o Azure Monitor Agent.

**Metodologia:**
Demonstração técnica e hands‑on.

**Avaliação:**
Servidor corretamente ligado ao Azure Arc.

---

**Sessão 8 (2h)**

**Objetivo Geral:**
Monitorizar desempenho e eventos em ambientes híbridos.

**Objetivos Específicos:**

* Criar Data Collection Rules;
* Criar queries KQL;
* Criar alertas de performance.

**Metodologia:**
Resolução de cenários práticos.

**Avaliação:**
Criação de um alerta funcional para Arc Machines.

---

### Dia 5 — Dashboards, Integrações, Governance e Custos (4h)

**Sessão 9 (2h)**

**Objetivo Geral:**
Criar visões operacionais e integrar alertas.

**Objetivos Específicos:**

* Criar Workbooks;
* Criar Dashboards;
* Integrar alertas com Teams e Jira.

**Metodologia:**
Hands‑on intensivo.

**Avaliação:**
Workbook operacional criado e partilhado.

---

**Sessão 10 (2h)**

**Objetivo Geral:**
Garantir governance e otimização de custos.

**Objetivos Específicos:**

* Controlar custos do Log Analytics;
* Criar políticas de diagnóstico;
* Definir um plano de implementação.

**Metodologia:**
Demonstração prática e exercício aplicado.

**Avaliação:**
Elaboração de um mini plano de implementação de Azure Monitor.

---

## Recursos Pedagógicos

* Azure Portal
* Laboratórios práticos
* Documentação oficial Microsoft
* Slides de apoio

---

## Certificação / Comprovativo

Emissão de certificado de frequência mediante participação mínima definida pela entidade formadora.
