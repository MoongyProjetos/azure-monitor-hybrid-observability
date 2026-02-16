# 📘 Sessão 5 – Monitorização de Dados e Storage

---

## 🎯 Objetivos da Sessão

* Monitorar desempenho e disponibilidade de Azure SQL.
* Compreender métricas DTU/vCore e seu impacto operacional.
* Utilizar Query Store e SQL Insights para investigação.
* Monitorar Storage Accounts e prevenir indisponibilidade.
* Definir padrão organizacional para observabilidade de dados.

---

# 🗄️ Parte 1 – Azure SQL

Pergunta inicial para o grupo:

> Se o banco parar, o que acontece com o negócio?

Normalmente a resposta é: tudo para.

Então monitoramento de dados não é opcional.

---

## 📊 Métricas DTU / vCore

Dependendo do modelo adotado:

### 🔹 DTU Model

* Percentual de consumo
* CPU
* IO
* Memory

### 🔹 vCore Model

* CPU
* Data IO
* Log IO
* Workers

Você precisa explicar:

> Alta CPU não significa necessariamente problema.
> Pode significar carga saudável.

Aqui entra maturidade de análise.

---

# 🧠 SQL Insights

SQL Insights permite:

* Visão consolidada de múltiplos bancos
* Análise de performance
* Identificação de gargalos
* Correlação com infraestrutura

Pergunta estratégica:

> Vocês monitoram o banco ou só esperam o alerta de indisponibilidade?

---

# 🔍 Query Store

Ferramenta essencial para:

* Identificar queries lentas
* Comparar performance histórica
* Detectar regressão após deploy

Aqui você pode mostrar:

Uma query lenta não é problema de CPU.
Pode ser problema de índice, plano de execução ou padrão de uso.

---

# 🛠️ Hands-on 1 – Investigação de Performance

Simular:

* Query lenta
* Pico de DTU
* Lock ou blocking

Investigar:

1. Métrica indica problema
2. SQL Insights mostra gargalo
3. Query Store revela query problemática

Isso ensina investigação completa.

---

# 💾 Parte 2 – Storage Accounts

Storage é invisível até dar problema.

Mas impacta:

* Aplicações
* Containers
* Backup
* Integrações

---

## 📊 Métricas Críticas de Storage

* Latência
* Disponibilidade
* Throttling
* Ingress/Egress
* Transações

Pergunta estratégica:

> Vocês monitoram latência ou só disponibilidade?

---

# 📄 Logs de Storage

Permitem:

* Detectar falhas de acesso
* Erros 403/404
* Operações mal sucedidas
* Analisar uso indevido

Aqui você conecta com:

Sessão 4 – Alertas inteligentes.

---

# 🛠️ Hands-on 2 – Monitorando Storage

1. Criar alerta para throttling
2. Analisar latência
3. Criar visualização simples

Pergunta estratégica:

> Storage crítico deve ter alerta ou só dashboard?

---

# 🧩 Discussão Estratégica (15 min)

Perguntas importantes:

1. Banco é considerado crítico?
2. Existe janela de tolerância para lentidão?
3. Existe monitoramento proativo de query?
4. Storage tem padrão mínimo de monitoramento?
5. Quem é responsável por banco?

Aqui você começa a preencher:

Seção 3 e 4 do documento estratégico.

---

# 🧠 Conexão com Próxima Sessão

Agora já monitoramos:

* Aplicações
* Infra
* Dados

Próxima etapa:

> Containers e workloads modernos.

Que trazem complexidade adicional.

---

# 🎯 Resultado Esperado da Sessão 5

Ao final desta sessão:

* O grupo entende que banco precisa de monitoramento específico.
* SQL Insights e Query Store passam a ser vistos como obrigatórios.
* Storage deixa de ser invisível.
* A empresa começa a definir padrão mínimo de monitoramento de dados.
