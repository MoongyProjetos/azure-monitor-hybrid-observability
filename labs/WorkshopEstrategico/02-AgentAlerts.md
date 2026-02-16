# 🧪 Laboratório Hands-on 2 – Padronização com Azure Monitor Agent, DCR e Alertas: Definir como a empresa vai coletar e reagir.

---

## 🎯 Objetivos do Laboratório

* Compreender a diferença entre MMA (legado) e AMA (modelo moderno).
* Implementar Azure Monitor Agent (AMA).
* Criar e aplicar Data Collection Rules (DCR).
* Validar ingestão padronizada.
* Criar primeiro alerta operacional estruturado.
* Iniciar definição de padrão organizacional de coleta e alerta.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização deseja:

* Padronizar coleta de dados.
* Evitar configurações descentralizadas.
* Reduzir ingestão desnecessária.
* Criar modelo consistente de alertas.

Hoje:

* Pode haver agentes antigos.
* Pode não haver padrão.
* Pode haver coleta excessiva.

Este laboratório serve para:

> Definir o modelo moderno de coleta e alerta.

---

# 🔎 Parte 0 — Diagnóstico Rápido (10–15 min)

Perguntas ao grupo:

1. Ainda utilizam MMA?
2. Existe padrão de agente?
3. Cada time cria sua própria coleta?
4. Existe controle de ingestão?
5. Já houve surpresa de custo?

📌 Registrar respostas.

---

# Parte 1 — Verificar Agente Atual

Se houver VM disponível:

1. Abrir VM
2. Extensões
3. Verificar se há Log Analytics Agent (MMA)
4. Verificar se há Azure Monitor Agent

---

## 🧠 Discussão Estratégica

Perguntar:

> Vamos adotar AMA como padrão único?

Registrar decisão preliminar.

---

# Parte 2 — Implementar Azure Monitor Agent

## Passo 1 — Instalar AMA

1. Abrir VM
2. Extensions + applications
3. Add → Azure Monitor Agent
4. Confirmar instalação

---

# Parte 3 — Criar Data Collection Rule (DCR)

## Passo 2 — Criar DCR

1. Procurar **Data Collection Rules**
2. Create

Configuração sugerida:

* Name: dcr-standard-windows
* Resource Group: rg-observability-workshop
* Destination: Log Analytics Workspace criado na Sessão 1

---

## Selecionar Coleta

Adicionar:

* Performance counters essenciais
* Event Logs (System + Application)

---

## Associar DCR à VM

Selecionar:

* Target resource → VM

Salvar.

---

# 🧠 Discussão Estratégica

Perguntar:

1. Devemos ter DCR por tipo de servidor?
2. DCR por ambiente?
3. DCR mínima obrigatória?
4. Quem aprova mudança de DCR?

Aqui você começa a desenhar política interna.

---

# Parte 4 — Validar Ingestão

Abrir:

Log Analytics → Logs

Testar:

```kql
Heartbeat
| summarize LastSeen = max(TimeGenerated) by Computer
```

Confirmar que VM está enviando dados via AMA.

---

# Parte 5 — Criar Primeiro Alerta Estruturado

## Cenário

Servidor com CPU acima de 80% por 10 minutos.

---

## Passo 3 — Criar Alerta de Métrica

1. VM → Alerts → Create Alert Rule
2. Condition → CPU Percentage
3. Threshold → 80%
4. Time aggregation → 10 min
5. Severity → 2 (Warning)

---

## Configurar Action Group

Criar Action Group:

* Nome: ag-ops-core
* Tipo: Email ou Teams (se possível)

---

# 🧠 Discussão Estratégica

Perguntar:

1. Todo alerta deve gerar notificação?
2. Quem recebe?
3. Dev e Ops devem receber o mesmo?
4. Existe classificação por severidade?

Aqui você pode introduzir:

🔴 Crítico
🟠 Alto
🟡 Médio
🔵 Informativo

---

# Parte 6 — Introdução a Workbooks

Abrir:

Azure Monitor → Workbooks

Criar workbook simples:

* CPU média da VM
* Status de Heartbeat
* Contagem de eventos

Pergunta:

> Dashboard substitui alerta?

Resposta esperada: Não.

---

# 🧠 Momento Estratégico Final

Preencher junto com grupo:

✔ AMA será padrão único?
✔ DCR mínima obrigatória?
✔ Alertas com severidade definida?
✔ Action Group padrão organizacional?

Registrar decisões no documento estratégico.

---

# ✅ Resultados Esperados

Ao final do laboratório:

* AMA instalado e funcional.
* DCR criada e associada.
* Ingestão validada.
* Primeiro alerta estruturado criado.
* Modelo inicial de governança definido.

---

# 🚀 Extensão Opcional

Criar alerta baseado em KQL:

```kql
Heartbeat
| where TimeGenerated < ago(10m)
```

Cenário:

Servidor parou de enviar logs.

Pergunta:

> Esse alerta é mais crítico que CPU alta?

Provocar maturidade.

---

# 🎯 O que essa sessão constrói na prática?

Ela transforma:

Monitoramento técnico → Política organizacional.

