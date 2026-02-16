# 📘 Sessão 2 – Azure Monitor Agent, Data Collection Rules e Alertas

## 🎯 Objetivos da Sessão

* Compreender a evolução dos agentes de monitorização no Azure.
* Entender o papel do Azure Monitor Agent (AMA) na recolha moderna de dados.
* Criar e aplicar Data Collection Rules (DCR).
* Introduzir o modelo de alertas do Azure Monitor.

---

## 🧭 Evolução dos Agentes de Monitorização no Azure

A monitorização no Azure evoluiu ao longo do tempo para um modelo mais unificado e flexível.

### Gerações anteriores

**MMA (Microsoft Monitoring Agent)**

* Agente clássico do Log Analytics
* Configuração por workspace
* Gestão limitada e menos flexível

**Extensões de diagnóstico**

* Configuradas por recurso
* Fragmentação de configuração
* Baixa reutilização

Limitações principais:

* Configuração distribuída
* Difícil governança
* Pouca reutilização
* Complexidade operacional

---

## 🚀 Azure Monitor Agent (AMA)

O Azure Monitor Agent é o agente moderno e unificado do Azure Monitor.

Principais características:

* Configuração centralizada
* Recolha baseada em regras (DCR)
* Suporte Azure e híbrido (Arc)
* Multi-destino de dados
* Governança e escala

O AMA desacopla:

👉 **onde o agente está**
👉 **o que ele recolhe**

---

## 🧱 Data Collection Rules (DCR)

As Data Collection Rules definem:

* Que dados recolher
* De onde recolher
* Para onde enviar

Uma DCR pode incluir:

* Performance counters
* Event logs
* Syslog
* Métricas
* Logs personalizados

E pode enviar para:

* Log Analytics
* Metrics
* Event Hub
* Storage

---

## 🔗 Associação DCR → Recursos

Fluxo lógico:

**Recurso / VM / Arc Server**
→ associado a
**DCR**
→ envia dados para
**Destino (LAW / Metrics / etc.)**

Benefícios:

* Reutilização
* Consistência
* Governança
* Escalabilidade

---

## 🔔 Introdução ao Modelo de Alertas do Azure Monitor

O Azure Monitor permite criar alertas baseados em:

* Métricas
* Logs
* Activity Log
* Service Health

Estrutura de um alerta:

**Signal** → condição
**Condition** → regra
**Action Group** → notificação/ação

---

## 📊 Tipos de Alertas

### Alertas de Métricas

* Baixa latência
* Próximo do tempo real
* Ideal para infraestrutura

Exemplos:

* CPU > 80%
* Latência > X ms
* Falhas > N

---

### Alertas de Logs

* Baseados em KQL
* Alta flexibilidade
* Contexto rico

Exemplos:

* Erros específicos
* Eventos críticos
* Padrões operacionais

---

### Alertas de Activity Log

Eventos de controlo do Azure:

* Delete resource
* Stop VM
* Change config

---

## 🧠 Boas Práticas de Recolha e Alertas

* Centralizar via DCR
* Evitar duplicação de dados
* Separar métricas vs logs
* Alertar apenas sinais acionáveis
* Usar severidades consistentes

> 💡 Um bom alerta deve ser acionável e relevante, não apenas informativo.

---

## ✅ Conclusão da Sessão

Nesta sessão, entendemos:

* A evolução dos agentes de monitorização no Azure.
* O papel do Azure Monitor Agent (AMA).
* O conceito e funcionamento das Data Collection Rules.
* O modelo de alertas do Azure Monitor.

Na próxima sessão, vamos aplicar estes conceitos na **monitorização de aplicações com Application Insights e telemetria moderna**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor