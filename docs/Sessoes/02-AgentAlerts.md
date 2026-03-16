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

---
Para associar **Azure Monitor Agent (AMA)** e um **Data Collection Rule (DCR)** a uma VM no **Microsoft Azure**, o processo tem **2 passos principais**:

1️⃣ Instalar o **Azure Monitor Agent** na VM
2️⃣ Associar a VM a um **Data Collection Rule**

Vou te mostrar os métodos mais comuns.

---

# 1️⃣ Instalar o Azure Monitor Agent na VM

### Pelo Portal Azure (mais simples)

1. Vai em **Virtual Machines**
2. Abre a VM
3. Menu **Extensions + applications**
4. **Add**
5. Escolhe:

* **Azure Monitor Agent**

Instala a extensão:

* `AzureMonitorWindowsAgent` (Windows)
* `AzureMonitorLinuxAgent` (Linux)

---

# 2️⃣ Associar o Data Collection Rule (DCR)

Depois do agente instalado, precisa **associar a VM ao DCR**.

### Pelo Portal

1. Vai em **Monitor**
2. **Data Collection Rules**
3. Abre o DCR
4. **Resources**
5. **Add**
6. Seleciona a **VM**

Isso cria automaticamente uma **Data Collection Rule Association (DCRA)**.

---

# 3️⃣ Via Azure CLI (muito usado em automação)

Associar um DCR a uma VM:

```bash
az monitor data-collection rule association create \
  --name myDCRAssociation \
  --rule-id /subscriptions/<subId>/resourceGroups/<rg>/providers/Microsoft.Insights/dataCollectionRules/<dcrName> \
  --resource /subscriptions/<subId>/resourceGroups/<rg>/providers/Microsoft.Compute/virtualMachines/<vmName>
```

---

# 4️⃣ Via ARM / Bicep (infra as code)

Exemplo **Bicep**:

```bicep
resource dcrAssociation 'Microsoft.Insights/dataCollectionRuleAssociations@2021-04-01' = {
  name: 'myAssociation'
  scope: vm
  properties: {
    dataCollectionRuleId: dcr.id
  }
}
```

---

# Arquitetura final

Depois de configurado fica assim:

```
VM
 └ Azure Monitor Agent
      └ Data Collection Rule Association
            └ Data Collection Rule
                  └ Log Analytics Workspace
```

---

💡 **Dica importante (pega muita gente):**

* O **AMA não envia nada sozinho**
* **Só envia o que o DCR define**

Ou seja:

```
AMA + DCR = coleta de logs/métricas
```

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