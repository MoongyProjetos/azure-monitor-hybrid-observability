# 📘 Sessão 1 – Fundamentos da Observabilidade e Azure Monitor

## 🎯 Objetivos da Sessão

* Apresentar a estrutura do curso e os temas que serão abordados.
* Introduzir os conceitos fundamentais de observabilidade moderna.
* Compreender o papel do Azure Monitor na estratégia de monitorização.
* Distinguir métricas, logs e traces em ambientes cloud e híbridos.

---

## 🧭 Apresentação do Curso

![License](https://img.shields.io/badge/license-MIT-blue.svg)

### Objetivo Geral

Capacitar profissionais de IT na implementação de uma estratégia moderna de observabilidade utilizando Azure Monitor, permitindo monitorar aplicações, infraestruturas e ambientes híbridos com foco em confiabilidade operacional e experiência do utilizador.

### Metodologia

* **Exposição dialogada** com demonstrações no Azure Portal.
* **Cenários reais de operações e incidentes**.
* **Exercícios práticos guiados** ao longo da formação.
* **Construção progressiva de uma solução de observabilidade**.

---

## 🔎 O que é Observabilidade?

Observabilidade é a capacidade de compreender o estado interno de um sistema com base nos dados que ele produz.

Ela permite responder perguntas como:

* O sistema está saudável?
* Onde está a causa de um problema?
* O utilizador está a ter uma boa experiência?
* Como o sistema se comporta sob carga?

A observabilidade moderna baseia-se em três pilares principais:

* **Métricas** → valores numéricos ao longo do tempo (CPU, latência, throughput)
* **Logs** → registos detalhados de eventos
* **Traces** → fluxo de execução entre componentes

> 💡 Monitorização diz “algo está errado”.
> Observabilidade permite entender “por que está errado”.

---

## ☁️ O Papel do Azure Monitor

O Azure Monitor é a plataforma central da Microsoft para recolha, armazenamento, análise e visualização de dados de observabilidade em ambientes cloud e híbridos.

Ele permite:

* **Recolher métricas e logs** de recursos Azure e on-premises
* **Correlacionar dados de aplicações e infraestrutura**
* **Detetar anomalias com IA**
* **Criar alertas e dashboards operacionais**
* **Analisar incidentes e causa raiz**

Na prática, o Azure Monitor atua como o **“sistema nervoso” operacional** da plataforma Azure.

[Azure Monitor - Fundamentos](https://www.youtube.com/watch?v=XN4A-jNZ5Tk&t=63s)

---

## 🧱 Arquitetura do Azure Monitor (Visão Geral)

O Azure Monitor integra múltiplos componentes que trabalham em conjunto:

* **Data Sources** → recursos Azure, aplicações, VMs, containers, on-prem
* **Azure Monitor Agent (AMA)** → recolha moderna de dados
* **Log Analytics Workspace** → armazenamento e consulta de logs
* **Metrics Database** → armazenamento de métricas
* **Application Insights** → telemetria de aplicações
* **Alerting & Visualization** → alertas, dashboards e workbooks

Esta arquitetura permite uma visão unificada de ambientes:

* Cloud nativa
* Híbrida
* Containers
* Aplicações distribuídas

---

## 📊 Métricas vs Logs vs Traces

### Métricas

* Valores numéricos agregados ao longo do tempo
* Baixa latência e alto desempenho
* Ideais para alertas e dashboards

Exemplos:

* CPU
* Requests/sec
* Latência média
* Percentual de erros

---

### Logs

* Registos detalhados de eventos
* Contexto rico e consultável (KQL)
* Ideais para investigação

Exemplos:

* Erros de aplicação
* Eventos de sistema
* Auditoria
* Queries SQL

---

### Traces

* Fluxo de execução entre serviços
* Observabilidade de sistemas distribuídos
* Identificação de gargalos

Exemplos:

* Chamadas entre microserviços
* Dependências externas
* Tempo por componente

---

## ✅ Conclusão da Sessão

Nesta primeira sessão, entendemos:

* O conceito e os pilares da observabilidade moderna.
* O papel do Azure Monitor na monitorização cloud e híbrida.
* A arquitetura base da plataforma.
* As diferenças entre métricas, logs e traces.

Na próxima sessão, vamos configurar a **recolha moderna de dados com Azure Monitor Agent e Data Collection Rules**, além de introduzir alertas e workbooks.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor