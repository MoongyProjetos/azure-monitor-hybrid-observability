# 📘 Sessão 8 – Logs e Alertas em Ambientes Híbridos

## 🎯 Objetivos da Sessão

* Configurar Data Collection Rules (DCR) avançadas.
* Escrever queries KQL para monitoramento de infraestrutura.
* Criar alertas de performance em ambientes híbridos.
* Centralizar métricas e logs de múltiplas origens.

---

## 🌐 Observabilidade Unificada em Ambientes Híbridos

Após integrar servidores Azure e on-premises via Arc e AMA, o objetivo passa a ser:

* Coletar dados de forma padronizada
* Centralizar em um único workspace
* Consultar com KQL
* Criar alertas consistentes

Arquitetura típica:

Servidores Azure + Arc
→ AMA
→ DCR
→ Log Analytics
→ Azure Monitor

---

## 🧱 Data Collection Rules Avançadas

DCR avançadas permitem:

* Múltiplos data sources
* Múltiplos destinos
* Filtragem de eventos
* Reutilização em escala
* Segmentação por tipo de servidor

Exemplos de coleta avançada:

* Apenas eventos críticos
* Perf counters específicos
* Logs de aplicações
* Syslog por severidade

---

## 📊 Exemplos de Configuração Avançada

### Windows

* CPU %
* Memory Available
* Disk % Free
* Event Logs: System + Application
* Filtro: Level ≥ Error

---

### Linux

* CPU
* Memory
* Disk
* Syslog: Warning+

---

## 🔎 KQL para Infraestrutura Híbrida

Com dados centralizados, é possível consultar toda a infraestrutura:

Exemplo – CPU média por servidor:

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by Computer
| sort by avg_CounterValue desc
```

---

### Servidores com CPU alta

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer
| where avgCPU > 80
```

---

### Último heartbeat por servidor

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
```

---

### Eventos críticos

```kql
Event
| where EventLevelName == "Error"
| summarize count() by Computer
```

---

## 🔔 Alertas de Performance Híbrida

Alertas podem ser aplicados a:

* VMs Azure
* Servidores Arc
* On-premises
* Multi-cloud

Tipos:

* Métrica (CPU/memória)
* Log (KQL)
* Heartbeat
* Eventos críticos

---

## 📈 Exemplo – Alerta CPU Híbrido

Baseado em log:

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avgCPU=avg(CounterValue) by Computer, bin(TimeGenerated, 5m)
| where avgCPU > 80
```

Aplicável a:

👉 todos os servidores (Azure + Arc)

---

## ⚠️ Alerta de Servidor Offline

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

Detecta:

* VM parada
* Servidor on-prem offline
* Falha de agente

---

## 📦 Centralização de Métricas e Logs

Benefícios da centralização:

* Visão única da infraestrutura
* Consultas globais
* Alertas padronizados
* Governança
* Auditoria
* SRE

Permite responder:

* Qual servidor mais crítico?
* Qual ambiente mais instável?
* Onde há saturação?
* Qual cluster/host falha mais?

---

## 🧭 Estratégia de Monitoramento Híbrido

Boas práticas:

* Um workspace central
* DCR por tipo de servidor
* Queries reutilizáveis
* Alertas globais
* Severidade consistente
* Tags para segmentação

---

## 🧠 Boas Práticas de Alertas em Infraestrutura

* Alertar tendência, não pico isolado
* Usar média em janela
* Evitar thresholds arbitrários
* Cobrir offline e erros críticos
* Padronizar severidade
* Reduzir ruído

> 💡 Em ambientes híbridos, consistência é mais importante que ferramenta.

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Configurar DCR avançadas.
* Usar KQL para infraestrutura híbrida.
* Criar alertas de performance.
* Detectar servidores offline.
* Centralizar logs e métricas.

Na próxima sessão, vamos aplicar esses conceitos na **criação de dashboards e workbooks por perfil operacional**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor