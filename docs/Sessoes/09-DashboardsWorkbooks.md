# 📘 Sessão 9 – Dashboards e Workbooks por Perfil

## 🎯 Objetivos da Sessão

* Criar dashboards no Azure Monitor orientados por perfil.
* Construir Workbooks para Application Owners e IT Ops/SRE.
* Selecionar métricas e logs relevantes por persona.
* Aplicar boas práticas de visualização operacional.

---

## 👥 Observabilidade Orientada a Personas

Diferentes perfis consomem observabilidade de forma distinta:

**Application Owners**
Foco em experiência e aplicação

**IT Ops / SRE**
Foco em infraestrutura e disponibilidade

**Gestão**
Foco em SLA e saúde geral

Um bom dashboard responde:

👉 O que importa para este perfil?
👉 O que precisa ação?
👉 O que indica risco?

---

## 📊 Dashboards no Azure Monitor

Dashboards são visões rápidas com:

* Métricas
* Gráficos
* Logs
* Estado de recursos
* Alertas

Usados para:

* NOC
* Operação diária
* War room
* Status geral

---

## 📘 Azure Monitor Workbooks

Workbooks são visões analíticas interativas com:

* Métricas
* KQL
* Filtros
* Parâmetros
* Gráficos
* Tabelas

Permitem:

* Exploração
* Diagnóstico
* Observabilidade profunda
* Drill-down

---

## 🧑‍💻 Dashboard para Application Owners

Objetivo:

Experiência e saúde da aplicação.

Métricas típicas:

* Requests
* Latência
* Taxa de erro
* Dependências
* Disponibilidade

Exemplos de visualização:

* Latência média e P95
* Requests por minuto
* Falhas por endpoint
* Dependências lentas

---

## ⚙️ Dashboard para IT Ops / SRE

Objetivo:

Saúde da infraestrutura.

Métricas típicas:

* CPU servidores
* Memória
* Pods running
* Storage latency
* Servidores offline

Visualizações:

* CPU por servidor
* Nós AKS
* Heartbeat
* Alertas ativos
* Capacidade

---

## 📊 Workbooks por Persona

Workbooks permitem separar visões:

**Workbook App**
Requests, erros, UX

**Workbook Infra**
CPU, memória, nós

**Workbook Híbrido**
Azure + Arc

**Workbook Containers**
AKS

---

## 🔎 Exemplos de Queries para Workbooks

### Latência por aplicação

```kql
requests
| summarize avg(duration), p95=percentile(duration,95) by name
```

---

### CPU por servidor

```kql
Perf
| where CounterName == "% Processor Time"
| summarize avg(CounterValue) by Computer
```

---

### Servidores offline

```kql
Heartbeat
| summarize LastSeen=max(TimeGenerated) by Computer
| where LastSeen < ago(10m)
```

---

## 🎨 Boas Práticas de Visualização

* Mostrar o que exige ação
* Evitar excesso de gráficos
* Agrupar por domínio
* Usar cores consistentes
* Destacar anomalias
* Separar persona

---

## 🧭 Estrutura Recomendada de Workbooks

**Seção 1 – Saúde Geral**
Status e KPIs

**Seção 2 – Performance**
Latência / CPU

**Seção 3 – Falhas**
Erros

**Seção 4 – Capacidade**
Uso

**Seção 5 – Detalhe**
Tabela

---

## 🧠 Erros Comuns em Dashboards

* Métricas irrelevantes
* Dados demais
* Sem contexto
* Sem severidade
* Sem persona
* Sem atualização

> 💡 Um dashboard bom permite decidir em segundos.

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* Diferença entre dashboards e workbooks.
* Métricas por perfil operacional.
* Como estruturar visões por persona.
* Boas práticas de visualização.
* Queries úteis para observabilidade.

Na próxima sessão, vamos aplicar esses conceitos na **integração do Azure Monitor com outras plataformas e governance**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor
