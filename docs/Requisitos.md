Prezados,

Para a realização da formação **Azure Monitor para Ambientes Híbridos (Azure + On-Prem)**, que possui forte componente prática em ambiente Microsoft Azure, precisamos garantir previamente alguns requisitos técnicos para execução dos laboratórios pelos participantes.

Poderiam, por gentileza, apoiar na validação/preparação dos itens abaixo?

---

## 1️⃣ Subscrição Azure dos Participantes

Será utilizada a **subscrição Azure de formações** já existente.

Para garantir isolamento e evitar conflitos entre os participantes, solicitamos:

* Criação de **1 Resource Group por formando**
* Permissão **Contributor** para cada participante apenas no seu Resource Group
* Capacidade de criação de recursos dentro desse escopo

Os laboratórios envolvem criação de:

* Log Analytics Workspace
* Application Insights
* App Service
* Máquina Virtual
* AKS (Kubernetes)
* Storage Account
* Azure SQL Database
* Alertas e Data Collection Rules

---

## 2️⃣ Resource Group e Recursos Base (opcional, recomendado)

Para reduzir tempo de laboratório e evitar problemas de quotas, recomenda-se disponibilizar previamente:

* Resource Group: `rg-monitoring-lab`
* Log Analytics Workspace: `law-monitoring-lab`
* Região: **West Europe**

Caso possível, também ajuda disponibilizar:

* 1 VM por participante (ou por grupo)
* 1 cluster AKS compartilhado (opcional)

---

## 3️⃣ Permissões Recomendadas

Além de Contributor:

* Log Analytics Contributor
* Monitoring Contributor
* Kubernetes Cluster User (para labs AKS)

---

## 4️⃣ Ambiente Local dos Participantes

Para alguns laboratórios (AKS e Azure Arc), é necessário que as máquinas tenham:

* Azure CLI instalado
* kubectl instalado
* PowerShell 7+ (Windows) ou Bash (Linux/Mac)

Validação simples:

```
az version
kubectl version --client
```

---

## 5️⃣ Conectividade de Rede

Garantir que as máquinas dos participantes tenham:

* Acesso HTTPS (porta 443) à Internet
* Acesso ao portal Azure
* DNS funcional

Para laboratórios de Azure Arc, é necessário outbound HTTPS para endpoints Azure.

---

## 6️⃣ Quotas Azure

Solicitamos validar previamente quotas suficientes para:

* Máquinas virtuais
* AKS
* SQL Database
* Storage

Região: **West Europe**

---

## 7️⃣ Estratégia de Ambiente (sugestão)

Estratégia adotada:

* Subscrição compartilhada de formação
* **1 Resource Group por participante**

Essa abordagem reduz consumo de quotas e acelera os laboratórios, mantendo isolamento entre os ambientes.

