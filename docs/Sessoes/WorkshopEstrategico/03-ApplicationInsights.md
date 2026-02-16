# 📘 Sessão 3 – Observabilidade de Aplicações com Application Insights

---

## 🎯 Objetivos da Sessão

* Compreender a importância da observabilidade no nível da aplicação.
* Configurar e utilizar Application Insights.
* Correlacionar métricas, logs e traces de aplicações.
* Avaliar experiência do usuário com base em telemetria real.
* Iniciar a definição de padrão organizacional para monitoramento de aplicações.

---

# 🧭 Por que Aplicações são o Centro da Observabilidade?

Infraestrutura pode estar saudável…

Mas o usuário pode estar sofrendo.

A pergunta muda de:

> “O servidor está ok?”

para:

> “O usuário está conseguindo usar o sistema?”

Essa é a virada de maturidade.

---

# ☁️ Monitorização de App Services

## O que monitorar?

* CPU
* Memória
* Requests por segundo
* Taxa de erro
* Latência média
* Disponibilidade

Mas isso ainda é nível infraestrutura.

Para maturidade real, precisamos de:

* Dependências externas
* Exceções
* Fluxo de requisições
* Impacto no usuário

---

# 🔎 Application Insights

Application Insights é o componente do Azure Monitor focado em aplicações.

Ele permite:

* Coletar telemetria automaticamente
* Registrar exceções
* Mapear dependências
* Medir tempo de resposta
* Detectar degradação
* Correlacionar falhas

---

## Arquitetura Simplificada

```
Aplicação → SDK / Auto-Instrumentação → Application Insights → Log Analytics
```

Ele conecta:

* Requests
* Dependencies
* Exceptions
* Traces
* Custom Events

---

# 📊 Métricas, Logs e Traces na Aplicação

Aqui você conecta com a Sessão 1.

## Métricas

* Requests/sec
* Latência média
* Percentual de erro
* Apdex

---

## Logs

* Exceptions
* Logs estruturados
* Eventos customizados
* Auditoria

---

## Traces

* Chamadas entre serviços
* Dependências externas
* Tempo por camada
* Fluxo completo da requisição

---

# 🧠 Correlação de Dados

Application Insights permite:

* Identificar requisição lenta
* Ver qual dependência atrasou
* Ver qual exceção ocorreu
* Identificar padrão recorrente

Isso é investigação moderna.

---

# 👤 Telemetria e Experiência do Usuário

Pergunta estratégica:

> Vocês monitoram infraestrutura ou experiência do usuário?

Application Insights permite medir:

* Tempo real de resposta
* Falhas por região
* Comportamento do usuário
* Performance percebida

Aqui você pode introduzir:

* Apdex Score
* Disponibilidade real
* Falhas silenciosas

---

# 🛠️ Hands-on Estratégico

## Lab 1 – Habilitar Application Insights

* Ativar no App Service
* Explorar métricas
* Ver Requests
* Ver Exceptions

---

## Lab 2 – Analisar uma Falha

Simular:

* Erro HTTP 500
* Dependência lenta
* Timeout externo

Investigar:

* Onde começou
* Qual dependência afetou
* Impacto no usuário

---

# 🧩 Discussão Estratégica (15 min)

Perguntas críticas:

1. Todas as aplicações críticas devem ter Application Insights?
2. Existe padrão de telemetria?
3. Desenvolvedores registram logs estruturados?
4. Existe métrica de negócio monitorada?
5. Existe SLA formal?

Aqui você começa a definir padrão organizacional.

---

# 📌 Conexão com Sessão 4

Agora que sabemos:

* Coletar dados
* Monitorar aplicações
* Correlacionar sinais

Na próxima sessão vamos responder:

> Como transformar isso em alertas inteligentes e detecção proativa usando IA?

---

# 🎯 Resultado Esperado da Sessão 3

Ao final desta sessão:

* O grupo entende que infraestrutura não é suficiente.
* Application Insights passa a ser visto como obrigatório para aplicações críticas.
* A empresa começa a discutir padrão de telemetria.
* A base para alertas inteligentes está criada.
