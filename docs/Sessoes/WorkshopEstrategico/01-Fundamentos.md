# 📘 Sessão 1 – Fundamentos do Azure Monitor e Observabilidade

---

## 🎯 Objetivos da Sessão

* Nivelar conceitos de observabilidade moderna.
* Introduzir a arquitetura do Azure Monitor.
* Distinguir métricas, logs e traces/diagnostics.
* Mapear o estado atual de monitoramento da empresa.
* Criar base comum para decisões estratégicas ao longo da semana.

---

# 🧭 Parte 1 – Diagnóstico Inicial (Workshop Estratégico)

⏱️ 30–45 minutos

Antes de falar de Azure, você precisa entender onde eles estão.

---

## 🔎 Perguntas-Chave para o Grupo

1. O que vocês monitoram hoje?
2. Qual ferramenta utilizam?
3. Quem recebe os alertas?
4. Existe padrão de monitoramento?
5. Containers já são críticos?
6. Existe Application Insights ou algo equivalente?
7. Vocês sofrem com alert fatigue?
8. Existe SLO formal definido?

Enquanto eles respondem, você organiza no quadro:

```
Aplicações
Infraestrutura
Containers
On-Prem
Alertas
Ferramentas
Governança
```

💡 Isso vira o mapa da semana.

---

# 🔎 O que é Observabilidade?

Observabilidade é a capacidade de compreender o estado interno de um sistema com base nos sinais que ele produz.

Ela permite responder:

* O sistema está saudável?
* Onde está o problema?
* O usuário está sendo impactado?
* O comportamento mudou?
* Existe degradação silenciosa?

---

## 📌 Monitoramento vs Observabilidade

> Monitoramento diz: “Algo está errado.”
> Observabilidade responde: “Por que está errado?”

Essa diferença é essencial para maturidade operacional.

---

# 🧱 Os 3 Pilares da Observabilidade Moderna

https://www.youtube.com/watch?v=XN4A-jNZ5Tk&t=63s

## 📊 Métricas

* Valores numéricos ao longo do tempo
* Alta performance
* Ideais para alertas

Exemplos:

* CPU
* Latência
* Requests por segundo
* Percentual de erro

---

## 📄 Logs

* Eventos detalhados
* Alto contexto
* Consultáveis via KQL
* Fundamentais para investigação

Exemplos:

* Exceções
* Eventos de sistema
* Logs de containers
* Queries SQL

---

## 🔍 Traces

* Fluxo entre serviços
* Correlação entre componentes
* Essenciais para sistemas distribuídos

Exemplos:

* Chamadas entre microserviços
* Dependências externas
* Tempo por camada

---

# ☁️ O Papel do Azure Monitor

O Azure Monitor é a plataforma central de observabilidade da Microsoft.

Ele permite:

* Coletar métricas e logs
* Correlacionar aplicações e infraestrutura
* Detectar anomalias com IA
* Criar alertas acionáveis
* Construir dashboards operacionais

Na prática, ele funciona como o:

> Sistema nervoso operacional da plataforma Azure.

---

# 🏗️ Arquitetura do Azure Monitor (Visão Estratégica)

## Componentes principais:

* Data Sources (Apps, VMs, AKS, On-Prem)
* Azure Monitor Agent (AMA)
* Data Collection Rules
* Log Analytics Workspace
* Metrics Store
* Application Insights
* Alerting & Workbooks

Fluxo simplificado:

```
Recurso → Coleta → Armazenamento → Análise → Ação
```

---

# 🧠 Log Analytics Workspace

É o repositório central de logs.

Ele permite:

* Consultas via KQL
* Correlação de eventos
* Base para alertas
* Base para dashboards

Pergunta estratégica:

> Hoje vocês têm workspace único ou fragmentado?

Isso já prepara terreno para governança.

---

# 🔄 Métricas vs Logs vs Diagnostics

Métricas:

* Baixo custo
* Alta performance
* Boa para alertas simples

Logs:

* Alto detalhe
* Melhor para investigação

Diagnostics:

* Configuração de envio de logs e métricas para destinos específicos
* Base para padronização organizacional

---

# 🧩 Mini Atividade Prática

Peça para o grupo classificar:

| Cenário                   | Métrica | Log | Trace |
| ------------------------- | ------- | --- | ----- |
| CPU alta                  |         |     |       |
| Erro HTTP 500             |         |     |       |
| Falha entre microserviços |         |     |       |
| Query lenta               |         |     |       |

Isso engaja e fixa conceito.

---

# 🧠 Encerramento Estratégico da Sessão

Pergunta final:

> Se vocês tivessem que redesenhar a estratégia de monitoramento hoje, o que manteriam e o que mudariam?

Anote as respostas.

Isso alimenta o documento final.

---

# 📌 Resultado Esperado da Sessão 1

Ao final dessa sessão:

* Todos falam a mesma linguagem.
* Você entende maturidade real.
* O grupo começa a pensar estrategicamente.
* A semana ganha direção.
