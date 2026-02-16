# 📘 Sessão 2 – Azure Monitor Agent, DCR e Alertas

---

## 🎯 Objetivos da Sessão

* Compreender a evolução dos agentes de monitoramento no Azure.
* Entender o papel do Azure Monitor Agent (AMA) na arquitetura moderna.
* Configurar Data Collection Rules (DCR) de forma padronizada.
* Introduzir alertas como mecanismo operacional estruturado.
* Iniciar a definição de um modelo padrão de coleta para a empresa.

---

# 🔄 Evolução dos Agentes de Monitoramento

Antes de falar de configuração, é importante entender o contexto.

## 🟡 1ª Geração – Log Analytics Agent (MMA)

* Configuração local
* Dependente de workspace
* Difícil padronização
* Modelo legado

Problemas comuns:

* Falta de governança
* Configurações inconsistentes
* Baixa reutilização

---

## 🟠 Extensões de Diagnóstico

* Configuração por recurso
* Modelo fragmentado
* Pouca padronização organizacional

---

## 🟢 3ª Geração – Azure Monitor Agent (AMA)

Modelo moderno e recomendado.

Principais vantagens:

* Separação entre agente e política de coleta
* Uso de Data Collection Rules
* Reutilização de configuração
* Governança centralizada
* Integração com Azure Arc
* Melhor controle de custo

> 💡 Estratégia moderna = AMA + DCR como padrão organizacional.

---

# 🧠 Discussão Estratégica (10–15 min)

Perguntas para o grupo:

1. Vocês ainda utilizam MMA?
2. Existe padrão de coleta?
3. Cada time decide o que enviar para o Log Analytics?
4. Existe controle de ingestão?

Essa discussão já começa a desenhar a futura estratégia.

---

# 🏗️ Azure Monitor Agent (AMA)

O AMA é responsável por:

* Coletar logs e métricas
* Enviar dados conforme definido pela DCR
* Suportar ambientes Azure e híbridos

Ele não decide o que coletar.
Quem decide é a DCR.

Isso é arquitetura moderna.

---

# 📜 Data Collection Rules (DCR)

As DCR definem:

* Quais logs coletar
* Quais métricas coletar
* Para qual workspace enviar
* Frequência e granularidade

Modelo conceitual:

```
Recurso → AMA → DCR → Workspace
```

Benefícios:

* Padronização organizacional
* Redução de erro humano
* Facilidade de auditoria
* Controle de custo

---

# 🛠️ Hands-on Estratégico

## Lab 1 – Criar Log Analytics Workspace

* Criar workspace
* Definir retenção
* Entender impacto no custo

Pergunta estratégica:

> Workspace único para tudo ou segmentado por ambiente?

---

## Lab 2 – Criar Data Collection Rule

* Criar DCR
* Associar a uma VM
* Validar ingestão
* Consultar dados via KQL

Pergunta estratégica:

> DCR por tipo de workload ou por ambiente?

---

# 🚨 Introdução a Alertas

Agora que sabemos coletar dados, precisamos agir sobre eles.

---

## O que é um alerta eficaz?

Um alerta deve:

* Ser acionável
* Ter dono
* Ter contexto
* Evitar ruído

---

## Tipos de Alertas

* Baseado em métricas
* Baseado em logs (KQL)
* Threshold fixo
* Threshold dinâmico

---

## Fluxo Operacional

Alerta → Notificação → Ação → Resolução

Perguntas para o grupo:

1. Quem recebe alertas hoje?
2. Existe Action Group padronizado?
3. Alertas criam incidente automaticamente?
4. Existe integração com Teams ou outra ferramenta?

---

# 📊 Introdução a Workbooks

Workbooks permitem:

* Criar visualizações personalizadas
* Correlacionar dados
* Criar visão por perfil

Eles serão aprofundados na Sessão 9, mas aqui você mostra:

> Dados só geram valor quando são visualizados corretamente.

---

# 🧠 Encerramento Estratégico da Sessão

Ao final da sessão, o grupo deve refletir:

* Qual será nosso padrão de agente?
* Como vamos padronizar DCR?
* Como evitar coleta desnecessária?
* Como reduzir alert fatigue desde o início?

---

# 📌 Resultado Esperado da Sessão 2

Ao final desta sessão:

* A empresa entende a importância do AMA.
* O grupo compreende DCR como mecanismo de governança.
* Alertas começam a ser tratados como processo operacional.
* A arquitetura base da estratégia começa a se formar.
