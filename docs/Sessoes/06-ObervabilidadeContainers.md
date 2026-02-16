# 📘 Sessão 6 – Observabilidade de Containers e Workloads

## 🎯 Objetivos da Sessão

* Compreender a observabilidade de workloads em containers no Azure.
* Monitorar clusters do Azure Kubernetes Service (AKS).
* Utilizar Container Insights para métricas e logs.
* Monitorar Azure Container Instances (ACI).
* Analisar disponibilidade e performance de workloads containerizados.

---

## 🧱 Observabilidade em Ambientes Containerizados

Workloads em containers são dinâmicos e distribuídos:

* Pods efêmeros
* Escala automática
* Serviços distribuídos
* Múltiplos nós

Desafios de observabilidade:

* Identificar falhas por pod
* Detectar saturação de nós
* Monitorar rede entre serviços
* Analisar reinícios e crashes
* Correlacionar logs e métricas

Perguntas típicas:

* Qual pod está falhando?
* O nó está saturado?
* O cluster tem capacidade?
* O serviço está disponível?

---

## ☸️ Azure Kubernetes Service (AKS)

O AKS é o serviço gerenciado de Kubernetes no Azure.

Componentes monitorados:

* Cluster
* Nodes
* Pods
* Containers
* Deployments
* Services

Sinais principais:

* CPU / memória por node
* CPU / memória por pod
* Restarts
* Estado do pod
* Latência de rede

---

## 📊 Container Insights

Container Insights é a solução do Azure Monitor para observabilidade de Kubernetes e containers.

Coleta:

* Métricas de cluster
* Métricas de nós
* Métricas de pods
* Logs de containers
* Eventos Kubernetes

Arquitetura:

AKS → AMA / agent → Log Analytics → Insights

---

## 🧭 Visões do Container Insights

**Cluster**
Capacidade e utilização geral

**Nodes**
CPU/memória por nó

**Controllers**
Deployments e réplicas

**Pods**
Estado e consumo

**Containers**
CPU/memória/restarts

**Logs**
Logs de containers

---

## 📈 Métricas de Workloads Containerizados

Principais métricas:

* CPU %
* Memory %
* Node utilization
* Pod restarts
* Pod status
* Network

Interpretação:

* CPU alto → saturação
* Memory alto → risco OOM
* Restarts → instabilidade
* Pending → falta de capacidade

---

## 📜 Logs de Containers

Logs incluem:

* stdout/stderr
* erros de aplicação
* eventos runtime
* mensagens de health

Consultáveis via KQL:

```kql
ContainerLog
| take 50
```

Permite:

* Diagnóstico de falhas
* Erros de aplicação
* Crash loops
* Problemas de deploy

---

## 📦 Azure Container Instances (ACI)

ACI executa containers sem cluster Kubernetes.

Observabilidade inclui:

* CPU/memória
* Estado do container
* Logs stdout/stderr
* Exit code

Usado para:

* Jobs
* Processamento pontual
* Containers efêmeros

---

## 📚 Azure Container Registry (ACR)

ACR armazena imagens de container.

Monitoramento cobre:

* Pulls
* Pushes
* Latência
* Falhas
* Autenticação

Permite responder:

* Quem puxou imagem?
* Há falhas de pull?
* Há gargalo de registry?

---

## 📊 Disponibilidade e Performance de Workloads

Indicadores principais:

* Pods Running %
* Restarts
* Latência
* Requests falhados
* Saturação de nós

Sinais de problema:

* Pods Pending
* CrashLoopBackOff
* CPU throttling
* OOMKilled

---

## 🧠 Boas Práticas de Observabilidade em Containers

* Monitorar nós e pods separadamente
* Alertar restarts e crash loops
* Monitorar capacidade do cluster
* Correlacionar logs e métricas
* Versionar imagens no ACR
* Separar ambientes por cluster

> 💡 Em Kubernetes, disponibilidade depende da saúde dos pods e da capacidade dos nós.

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Observabilidade de workloads em AKS.
* Uso do Container Insights.
* Monitoramento de ACI e ACR.
* Métricas e logs de containers.
* Indicadores de disponibilidade e performance.

Na próxima sessão, vamos aplicar esses conceitos na **monitorização de infraestrutura híbrida com Azure Arc**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor