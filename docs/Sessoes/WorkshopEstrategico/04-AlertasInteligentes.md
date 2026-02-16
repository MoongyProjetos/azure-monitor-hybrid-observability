# 📘 Sessão 4 – Alertas Inteligentes e Análise com IA

---

## 🎯 Objetivos da Sessão

* Criar alertas baseados em métricas e logs.
* Desenvolver consultas KQL para cenários operacionais.
* Aplicar Smart Detection no Application Insights.
* Utilizar Dynamic Thresholds para reduzir ruído.
* Compreender análise assistida para identificação de causa raiz.
* Iniciar a definição de um modelo organizacional de alertas.

---

# 🚨 Parte 1 – O que é um Alerta de Verdade?

Antes de criar alertas, você precisa provocar:

Pergunta para o grupo:

> Vocês recebem alertas demais ou de menos?

---

## 📌 Princípios de um Alerta Eficaz

Um alerta deve ser:

* Acionável
* Claro
* Ter responsável definido
* Contextualizado
* Raro o suficiente para ser levado a sério

> Alerta não é notificação.
> Alerta é gatilho operacional com responsabilidade definida.

---

# 📊 Alertas Baseados em Métricas

Ideais para:

* CPU alta
* Uso de memória
* Latência acima do esperado
* Percentual de erro

Características:

* Rápidos
* Simples
* Baixo custo

---

# 📄 Alertas Baseados em Logs (KQL)

Mais poderosos e flexíveis.

Permitem:

* Detecção de padrões complexos
* Erros específicos
* Combinação de múltiplas condições
* Lógica customizada

Exemplo conceitual:

```
requests
| where resultCode == "500"
| summarize count() by bin(TimeGenerated, 5m)
```

Aqui você mostra que:

KQL transforma log em inteligência.

---

# 🛠️ Hands-on 1 – Criando Alertas

1. Criar alerta baseado em métrica (ex: erro > 5%)
2. Criar alerta baseado em KQL
3. Configurar Action Group
4. Testar disparo

Pergunta estratégica:

> Quem deve receber esse alerta? Dev? Ops? Ambos?

---

# 🤖 Parte 2 – IA Aplicada à Observabilidade

Agora vem a virada de maturidade.

---

## 🔎 Smart Detection (Application Insights)

Detecta automaticamente:

* Degradação de performance
* Aumento incomum de falhas
* Mudanças no padrão de requisições

Sem necessidade de regra manual.

Pergunta:

> Vocês preferem criar 50 alertas fixos ou deixar o sistema aprender padrão?

---

## 📈 Dynamic Thresholds

Em vez de:

CPU > 80%

O sistema aprende:

Qual é o comportamento normal daquele recurso.

Benefícios:

* Redução de falso positivo
* Detecção mais contextual
* Menos ruído

---

# 🔍 Parte 3 – Análise Assistida de Causa Raiz

Aqui você conecta tudo:

Exemplo prático:

1. Usuário relata lentidão
2. Ver latência média
3. Identificar dependência lenta
4. Correlacionar exceção
5. Confirmar padrão recorrente

Application Map ajuda a visualizar dependências.

Você ensina o fluxo de investigação moderno.

---

# 🧩 Discussão Estratégica (15 min)

Perguntas críticas:

1. Hoje vocês usam threshold fixo ou dinâmico?
2. Quem define o que gera alerta?
3. Existe processo de revisão de alertas?
4. Existe análise pós-incidente?
5. Alertas estão ligados a SLA?

Aqui você começa a construir:

Modelo oficial de alertas da empresa.

---

# 🧱 Mini-Framework que Você Pode Introduzir

### Classificação de Alertas

🔴 Crítico – Impacto direto no usuário
🟠 Alto – Degradação significativa
🟡 Médio – Atenção necessária
🔵 Informativo – Apenas dashboard

Isso ajuda na governança.

---

# 🔗 Conexão com as Próximas Sessões

Agora que sabemos:

* Criar alertas inteligentes
* Reduzir ruído
* Investigar causa raiz

Nas próximas sessões vamos aplicar isso em:

* SQL
* Storage
* Containers
* Infraestrutura híbrida

---

# 🎯 Resultado Esperado da Sessão 4

Ao final desta sessão:

* O grupo entende diferença entre alerta simples e alerta inteligente.
* Redução de alert fatigue passa a ser prioridade.
* IA é vista como ferramenta prática, não marketing.
* A base da estratégia de alertas da empresa começa a se consolidar.
