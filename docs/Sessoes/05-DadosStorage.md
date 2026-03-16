# 📘 Sessão 5 – Monitorização de Dados e Storage

## 🎯 Objetivos da Sessão

* Monitorar desempenho e utilização do Azure SQL.
* Compreender métricas DTU e vCore.
* Utilizar Query Store e SQL Insights para análise de queries.
* Monitorar Azure Storage Accounts.
* Analisar métricas e logs de serviços de dados.

---

## 🗄️ Observabilidade de Serviços de Dados no Azure

Serviços de dados são críticos para aplicações modernas e exigem monitoramento contínuo de:

* Performance de consultas
* Consumo de recursos
* Latência de acesso
* Erros e throttling
* Capacidade e crescimento

Perguntas típicas:

* O banco está sobrecarregado?
* Qual query está lenta?
* Há gargalo de I/O?
* O storage está saturado?

---

## 🧱 Azure SQL – Modelos de Capacidade

O Azure SQL possui dois modelos principais de provisionamento:

### DTU (Database Transaction Unit)

Modelo agregado de recursos:

* CPU
* Memória
* I/O

Exemplo:

* S2 = 50 DTUs
* S4 = 200 DTUs

Indica capacidade total disponível.

---

### vCore

Modelo baseado em recursos dedicados:

* vCPU
* Memória
* Storage

Mais previsível e escalável.

---

## 📊 Métricas do Azure SQL

Principais métricas monitoradas:

* CPU %
* DTU %
* Data IO %
* Log IO %
* Sessions
* Deadlocks
* Storage %

Interpretação:

* DTU % alto → saturação geral
* CPU alto → processamento
* IO alto → acesso a dados
* Log IO alto → transações

---

## 🔎 Query Store

O Query Store armazena histórico de execução de queries no Azure SQL.

Permite:

* Identificar queries lentas
* Comparar planos de execução
* Ver regressões após deploy
* Analisar consumo de CPU

Perguntas que responde:

* Qual query mais consome?
* Qual piorou após mudança?
* Qual tem maior duração?

---

## 📈 SQL Insights (Azure Monitor)

SQL Insights fornece observabilidade profunda do Azure SQL via Azure Monitor.

Capacidades:

* Performance por query
* Esperas (wait stats)
* Bloqueios
* Consumo de CPU/IO
* Sessões ativas

Arquitetura:

Azure SQL → AMA → Log Analytics → SQL Insights

---

## 🧭 Azure Storage – Observabilidade

Storage Accounts suportam:

* Blob
* Files
* Queues
* Tables

Monitoramento cobre:

* Latência
* Throughput
* Disponibilidade
* Transações
* Capacidade

---

## 📊 Métricas de Storage

Principais métricas:

* Transactions
* Availability
* Success E2E Latency
* Success Server Latency
* Ingress/Egress
* Capacity

Interpretação:

* Latência alta → gargalo
* Transactions alto → carga
* Availability baixa → erro
* Capacity alto → risco

---

## 📜 Logs de Storage

Logs registram operações:

* Read
* Write
* Delete
* Auth
* Errors

Permitem:

* Auditoria
* Diagnóstico
* Segurança
* Investigação

Exemplo de perguntas:

* Quem acessou o blob?
* Qual operação falhou?
* Qual cliente gera carga?

---

## 🧠 Boas Práticas de Monitorização de Dados

* Monitorar DTU/vCore continuamente
* Alertar saturação sustentada
* Usar Query Store para regressões
* Separar CPU vs IO vs Log
* Monitorar latência de storage
* Acompanhar crescimento de dados

> 💡 Em dados, o gargalo geralmente está em IO ou queries ineficientes.

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Métricas e capacidade do Azure SQL (DTU/vCore).
* Uso do Query Store para análise de queries.
* Observabilidade com SQL Insights.
* Métricas e logs do Azure Storage.
* Como identificar gargalos em serviços de dados.

Na próxima sessão, vamos aplicar esses conceitos na **observabilidade de containers e workloads (AKS, ACI, ACR)**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor