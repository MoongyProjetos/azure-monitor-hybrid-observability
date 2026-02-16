# 🧪 Laboratório Hands-on 3 – Observabilidade de Aplicações com Application Insights : aplicação é realmente observável — ou só “monitorada”?

---

## 🎯 Objetivos do Laboratório

* Ativar e configurar Application Insights em um App Service.
* Explorar métricas, logs e traces de aplicação.
* Correlacionar falhas e dependências.
* Avaliar experiência do usuário.
* Definir se Application Insights deve ser padrão organizacional.

---

## ⏱️ Duração Estimada

90 minutos

---

## 📋 Cenário Estratégico

A organização possui aplicações críticas hospedadas no Azure.

Hoje:

* Pode monitorar CPU.
* Pode monitorar disponibilidade.
* Pode ter alertas básicos.

Mas a pergunta real é:

> Conseguimos entender a experiência do usuário?

Este laboratório avalia se a empresa está no nível:

Infra monitorada
ou
Aplicação observável.

---

# 🔎 Parte 0 — Discussão Inicial (10 min)

Perguntas ao grupo:

1. Todas as aplicações críticas possuem Application Insights?
2. Desenvolvedores registram logs estruturados?
3. Existe métrica de negócio monitorada?
4. Existe análise pós-incidente baseada em telemetria?

Registrar respostas.

---

# Parte 1 — Ativar Application Insights

## Passo 1 — Verificar App Service

Abrir um App Service existente
ou criar um simples (se necessário).

---

## Passo 2 — Habilitar Application Insights

1. App Service → Monitoring → Application Insights
2. Enable
3. Criar novo recurso ou usar existente

Salvar.

---

# Parte 2 — Gerar Tráfego

Para ter dados:

* Acessar URL da aplicação várias vezes
* Simular erro (endpoint inexistente, se possível)

Objetivo:

Gerar requests, exceções e dependências.

---

# Parte 3 — Explorar Métricas

Abrir:

Application Insights → Metrics

Explorar:

* Requests
* Failed Requests
* Server Response Time
* Availability

---

## 🧠 Exercício Analítico

Responder:

1. Qual a latência média?
2. Existe erro?
3. Existe variação por horário?
4. Métrica sozinha permite entender causa raiz?

---

# Parte 4 — Explorar Logs (KQL para Aplicação)

Abrir:

Application Insights → Logs

---

## Query 1 — Requests

```kql
requests
| take 20
```

---

## Query 2 — Exceptions

```kql
exceptions
| summarize count() by type
```

---

## Query 3 — Dependências

```kql
dependencies
| summarize avg(duration) by target
| order by avg_duration desc
```

Objetivo:

Identificar dependência lenta.

---

# Parte 5 — Investigação Completa

Simular cenário:

Usuário reclama de lentidão.

Fluxo de investigação:

1. Ver latência média.
2. Identificar request lenta.
3. Ver dependência associada.
4. Ver exceção, se houver.

Mostrar:

Application Map.

---

# 🧠 Discussão Estratégica

Perguntas críticas:

1. Toda aplicação em produção deve ter Application Insights obrigatório?
2. Existe padrão mínimo de telemetria?
3. Métrica de negócio deve ser registrada?
4. Desenvolvedor é responsável por observabilidade?

Registrar decisões preliminares.

---

# Parte 6 — Experiência do Usuário

Explorar:

* Availability
* Performance
* Apdex (se disponível)
* Requests por região (se aplicável)

Pergunta:

> Infra saudável garante usuário satisfeito?

---

# 📌 Momento Estratégico

Preencher com o grupo:

✔ Application Insights será obrigatório para produção?
✔ Telemetria mínima definida?
✔ Logs estruturados obrigatórios?
✔ Métrica de negócio recomendada?

Isso alimenta o documento final.

---

# ✅ Resultados Esperados

Ao final do laboratório:

* Application Insights ativado.
* Requests e exceções analisados.
* Correlação entre métricas, logs e traces compreendida.
* Padrão organizacional começa a ser definido.
* Experiência do usuário entra na discussão estratégica.

---

# 🚀 Extensão Opcional

Criar gráfico com KQL:

```kql
requests
| summarize count() by bin(timestamp, 5m)
| render timechart
```

Depois perguntar:

> Isso deve gerar alerta automático?

---

# 🎯 O que esta sessão constrói?

Ela transforma:

“Monitoramos CPU”
em
“Entendemos o impacto no usuário”.
