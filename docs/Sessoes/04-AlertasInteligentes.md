# 📘 Sessão 4 – Alertas Inteligentes e Análise com IA

## 🎯 Objetivos da Sessão

* Criar alertas baseados em métricas e logs no Azure Monitor.
* Escrever queries KQL para detecção de condições operacionais.
* Compreender o funcionamento do Smart Detection no Application Insights.
* Aplicar Dynamic Thresholds para redução de falsos positivos.
* Utilizar recursos de IA para análise assistida de causa raiz.

---

## 🔔 Alertas no Azure Monitor

Alertas permitem detectar automaticamente condições anormais em aplicações e infraestrutura.

Podem ser baseados em:

* Métricas
* Logs (KQL)
* Activity Log
* Application Insights

Estrutura de um alerta:

**Signal (sinal)** → dado monitorado
**Condition (condição)** → regra de disparo
**Action Group** → notificação/automação

---

## 📊 Alertas de Métricas

Baseados em séries temporais numéricas.

Características:

* Baixa latência
* Próximo do tempo real
* Ideal para infraestrutura e performance

Exemplos:

* CPU > 80%
* Latência média > 2s
* Taxa de erro > 5%

---

## 📜 Alertas de Logs (KQL)

Baseados em consultas sobre dados no Log Analytics ou Application Insights.

Vantagens:

* Alta flexibilidade
* Contexto rico
* Detecção de padrões complexos

Exemplo:

```kql
requests
| where success == false
| summarize count() by bin(timestamp, 5m)
| where count_ > 10
```

Detecta: mais de 10 falhas em 5 minutos.

---

## 🔎 Queries KQL para Observabilidade

KQL (Kusto Query Language) é a linguagem de consulta do Azure Monitor.

Usos principais:

* Investigar incidentes
* Criar alertas
* Analisar telemetria
* Detectar anomalias

Exemplo – latência média por endpoint:

```kql
requests
| summarize avg(duration) by name
| sort by avg_duration desc
```

---

## 🤖 Smart Detection (Application Insights)

Smart Detection usa IA para identificar automaticamente padrões anormais na aplicação.

Detecta:

* Aumento anormal de falhas
* Degradação de performance
* Mudança de comportamento
* Falhas em dependências

Características:

* Baseado em histórico
* Sem configuração manual
* Orientado à experiência do usuário

Exemplo de insight:

> “Taxa de falhas aumentou 230% nas últimas 2h”

---

## 📈 Dynamic Thresholds

Dynamic Thresholds criam limites automáticos baseados no comportamento histórico do sistema.

Em vez de:

👉 CPU > 80% (fixo)

O Azure aprende:

👉 padrão normal da CPU
👉 variação diária/semanal
👉 sazonalidade

E alerta quando há desvio estatístico.

Benefícios:

* Menos falsos positivos
* Ajuste automático
* Sensível a padrões reais

---

## 🧠 Análise Assistida de Causa Raiz

O Azure Monitor e Application Insights ajudam a correlacionar sinais automaticamente:

* Requests
* Dependências
* Exceções
* Deploys
* Infraestrutura

Recursos:

* Smart Detection insights
* Application Map
* Failures analysis
* Transaction search

Objetivo:

Responder rapidamente:

👉 O que quebrou?
👉 Onde começou?
👉 O que mudou?

---

## 🧭 Boas Práticas de Alertas Inteligentes

* Alertar impacto no usuário, não só infraestrutura
* Preferir métricas para tempo real
* Usar logs para contexto
* Evitar thresholds fixos arbitrários
* Usar severidade consistente
* Reduzir ruído operacional

> 💡 Um bom alerta indica impacto real e ação necessária.

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Diferença entre alertas de métricas e logs.
* Como usar KQL para detecção operacional.
* Funcionamento do Smart Detection.
* Vantagens de Dynamic Thresholds.
* Como a IA ajuda na análise de causa raiz.

Na próxima sessão, vamos aplicar esses conceitos na **monitorização de dados e serviços de storage no Azure**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor