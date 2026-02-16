# 🧪 Laboratório Hands-on 6 – Observabilidade de Containers e Workloads : Container é onde muita empresa acha que está moderna… mas monitora como se fosse VM.

---

## 🎯 Objetivos do Laboratório

* Monitorar um cluster AKS com Container Insights.
* Investigar problemas em pods e nodes.
* Analisar performance e reinicializações.
* Monitorar Azure Container Instances (ACI).
* Monitorar Azure Container Registry (ACR).
* Definir padrão organizacional de observabilidade para containers.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização utiliza (ou planeja utilizar) containers.

Desafios:

* Pods são efêmeros
* Logs podem desaparecer
* Escala é dinâmica
* Restart pode mascarar falha

Objetivo:

> Garantir que containers não virem “caixa preta”.

---

# 🔎 Parte 0 — Diagnóstico Inicial (10 min)

Perguntas ao grupo:

1. AKS é crítico?
2. Existe padrão mínimo de monitoramento para novos clusters?
3. Existe alerta para restart excessivo?
4. Namespace tem responsabilidade definida?
5. Existe visibilidade consolidada entre app e container?

Registrar respostas.

---

# Parte 1 — Monitorando AKS com Container Insights

Abrir:

Azure Monitor → Containers

Selecionar cluster AKS.

---

## 🔹 Explorar Visão Geral

Analisar:

* Uso de CPU por node
* Uso de memória
* Pods ativos
* Namespace

---

## 🧠 Exercício Analítico

Responder:

1. Algum node está sobrecarregado?
2. Há pod consumindo mais memória que esperado?
3. Existe desequilíbrio entre nodes?

Provocar:

> Escala resolve problema ou mascara problema?

---

# Parte 2 — Investigando Restart de Pods

Ir em:

Workloads → Containers

Identificar:

* Restart count
* CrashLoopBackOff
* OOMKilled

---

## 🛠️ Simulação (se possível)

Forçar reinício de pod
ou analisar histórico de restart.

Perguntar:

1. Restart frequente é crítico?
2. Deve gerar alerta?
3. Qual severidade?

---

# Parte 3 — Logs de Containers

Abrir:

Container Insights → Logs

Query exemplo:

```kql
ContainerLog
| take 20
```

---

## 🔎 Query de Restart Frequente

```kql
KubePodInventory
| summarize Restarts = max(ContainerRestartCount) by PodName
| order by Restarts desc
```

Perguntar:

* Qual pod mais reiniciou?
* Isso é aceitável?

---

# Parte 4 — Monitorando Azure Container Instances (ACI)

Abrir ACI.

Ver:

* Estado do container
* Logs
* Uso de CPU/memória

Perguntar:

> ACI é workload temporário ou crítico?

Definir se precisa alerta formal.

---

# Parte 5 — Monitorando Azure Container Registry (ACR)

Abrir ACR.

Explorar:

* Métricas
* Storage usado
* Falhas de pull (se houver logs habilitados)

Perguntar:

1. Falha de pull impacta produção?
2. Deve haver alerta para erro de autenticação?
3. ACR faz parte da estratégia de observabilidade?

---

# 🧠 Conexão App + Container

Mostrar:

* Application Insights → latência
* Container Insights → consumo de pod
* Correlação entre ambos

Pergunta:

> Problema está na aplicação ou no container?

Isso é maturidade real.

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ Container Insights obrigatório para produção
✔ Alerta para restart excessivo
✔ Monitoramento mínimo por namespace
✔ ACR monitorado
✔ Correlação App + Container formalizada

---

# 🧠 Discussão Final

Perguntas críticas:

1. AKS deve ter DCR específica?
2. Containers devem ter padrão mínimo de logs?
3. Existe limite de recursos padronizado?
4. Observabilidade faz parte do pipeline?

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Cluster analisado.
* Restart identificado.
* Logs de container explorados.
* ACI e ACR avaliados.
* Padrão mínimo de monitoramento de containers definido.

---

# 🚀 Extensão Opcional

Criar alerta para:

Restart count > X em 10 min.

Perguntar:

> Restart frequente é sempre problema?

Provocar maturidade.

---

# 🎯 O que essa sessão constrói?

Ela transforma:

AKS monitorado superficialmente
em
Workload containerizado com governança de observabilidade.
