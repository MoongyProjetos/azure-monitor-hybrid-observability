# 📊 Workbook – Observabilidade Azure Monitor (Labs 1–10)

Nome sugerido:
**wb-observability-azure-monitor-labs**

Personas:

* Infra / SRE
* Aplicação
* Containers
* Dados
* Custos

---

# 🧭 Estrutura do Workbook

## 🔎 Seção 1 – Saúde da Infraestrutura

* Servidores offline
* CPU por servidor
* Erros por servidor

---

## ☸️ Seção 2 – Containers / AKS

* Pods não running
* Logs com erro
* CPU por pod

---

## 🌐 Seção 3 – Aplicações

* Latência P95
* Taxa de erro
* Requests no tempo

---

## 🗄️ Seção 4 – Dados

* Logs SQL
* Erros Storage
* Operações Blob

---

## 💰 Seção 5 – Custos

* Uso por tabela
* Ingestão por tipo

---

# 📘 JSON do Workbook

👉 copiar tudo abaixo 👇
👉 Azure Monitor → Workbooks → Advanced Editor → Paste → Apply

```json
{
  "version": "Notebook/1.0",
  "items": [
    {
      "type": 1,
      "content": {
        "json": "# Observabilidade – Azure Monitor\nWorkbook consolidado dos laboratórios (Infra, Apps, Containers, Dados e Custos)."
      }
    },
    {
      "type": 1,
      "content": {
        "json": "## 🔎 Saúde da Infraestrutura"
      }
    },
    {
      "type": 3,
      "content": {
        "version": "KqlItem/1.0",
        "query": "Heartbeat | summarize LastSeen=max(TimeGenerated) by Computer | where LastSeen < ago(10m)",
        "size": 0,
        "title": "Servidores Offline",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "version": "KqlItem/1.0",
        "query": "Perf | where CounterName == \"% Processor Time\" | summarize avgCPU=avg(CounterValue) by Computer | sort by avgCPU desc",
        "size": 0,
        "title": "CPU por Servidor",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "version": "KqlItem/1.0",
        "query": "Event | where EventLevelName == \"Error\" | summarize count() by Computer | sort by count_ desc",
        "size": 0,
        "title": "Erros por Servidor",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 1,
      "content": {
        "json": "## ☸️ Containers / AKS"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "KubePodInventory | where PodStatus != \"Running\"",
        "title": "Pods não Running",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "ContainerLog | where LogEntry contains \"error\"",
        "title": "Logs de Containers com Erro",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "InsightsMetrics | where Name == \"cpuUsageNanoCores\" | summarize avg(Val) by Tags[\"podName\"] | sort by avg_Val desc",
        "title": "CPU por Pod",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 1,
      "content": {
        "json": "## 🌐 Aplicações"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "requests | summarize avg(duration), p95=percentile(duration,95) by name | sort by p95 desc",
        "title": "Latência Média e P95",
        "queryType": 0,
        "resourceType": "microsoft.insights/components"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "requests | summarize total=count(), failures=countif(success==false) by name | extend errorRate = failures*100.0/total | sort by errorRate desc",
        "title": "Taxa de Erro por Endpoint",
        "queryType": 0,
        "resourceType": "microsoft.insights/components"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "requests | summarize count() by bin(timestamp,5m)",
        "title": "Requests ao Longo do Tempo",
        "queryType": 0,
        "resourceType": "microsoft.insights/components"
      }
    },
    {
      "type": 1,
      "content": {
        "json": "## 🗄️ Dados"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "AzureDiagnostics | where ResourceType == \"DATABASES\" | take 50",
        "title": "Logs SQL",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "StorageBlobLogs | where StatusCode >= 400",
        "title": "Erros Storage",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "StorageBlobLogs | summarize count() by OperationName",
        "title": "Operações Blob",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    },
    {
      "type": 1,
      "content": {
        "json": "## 💰 Custos"
      }
    },
    {
      "type": 3,
      "content": {
        "query": "Usage | summarize DataGB=sum(Quantity)/1024 by DataType | sort by DataGB desc",
        "title": "Uso por Tabela",
        "queryType": 0,
        "resourceType": "microsoft.operationalinsights/workspaces"
      }
    }
  ]
}
```

---

# ✅ Como importar no Azure

1. Azure Portal
2. Azure Monitor
3. Workbooks
4. New
5. Advanced Editor
6. Replace with JSON
7. Apply
8. Save
