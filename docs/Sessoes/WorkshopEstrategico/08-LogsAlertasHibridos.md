# 📘 Sessão 8 – Logs e Alertas em Ambientes Híbridos

---

## 🎯 Objetivos da Sessão

* Aprofundar o uso de Data Collection Rules (DCR) em cenários híbridos.
* Criar e reutilizar regras de coleta avançadas (padronização organizacional).
* Desenvolver consultas KQL para investigação de infraestrutura.
* Criar alertas de performance com base em logs e métricas.
* Consolidar estratégia de centralização de dados (métricas e logs) com governança.

---

# 🧠 Parte 1 – Por que “Avançado” em DCR é Estratégico?

Pergunta para o grupo:

> Hoje vocês conseguem garantir que todo servidor novo coleta os logs mínimos?

Se a resposta for não, a empresa não tem governança.

DCR avançadas permitem:

* Padronização por perfil de servidor (web, banco, infra)
* Reutilização por ambiente (dev/hml/prod)
* Controle de ingestão (custo)
* Auditoria e consistência

---

# 📜 Data Collection Rules Avançadas

## O que faz uma DCR ser “avançada”?

* Coletar múltiplos tipos de sinal (eventos, performance, syslog)
* Segmentar por workload / perfil
* Definir destino com clareza (workspace correto)
* Reutilizar para cloud e on-prem (Arc)
* Ser fácil de “copiar e colar” como padrão corporativo

---

## Padrões de DCR (modelo de workshop)

Você pode propor 3 perfis (exemplo):

### 🔹 DCR – Servidor Windows (Base)

* Performance counters essenciais
* Event Logs críticos

### 🔹 DCR – Servidor Linux (Base)

* Syslog essencial
* Métricas de CPU/mem/disco

### 🔹 DCR – Servidor Crítico (Extended)

* Mais granularidade
* Retenção diferenciada (se fizer sentido)
* Alertas obrigatórios

> 💡 O segredo é: poucas DCR bem definidas > dezenas de DCR aleatórias.

---

# 🔍 Parte 2 – KQL para Infraestrutura

Aqui você ensina KQL com foco 100% operacional.

Nada acadêmico.

## Tipos de perguntas que KQL deve responder:

* “Quais servidores estão com CPU alta há 15 min?”
* “Quais hosts tiveram reboot hoje?”
* “Quais máquinas estão sem enviar logs?”
* “Quais tiveram erro de disco?”
* “Quais têm pico de memória?”

---

## Mini Framework de KQL (prático)

Toda query operacional costuma ter:

* filtro (`where`)
* agrupamento (`summarize`)
* janela de tempo (`bin`)
* ordenação (`order by`)

---

# 🛠️ Hands-on 1 – Validar Coleta e Saúde de Ingestão

Você faz o grupo responder:

✅ “O servidor X está enviando logs corretamente?”
✅ “Qual foi o último log recebido?”
✅ “Existe buraco de ingestão?”

Isso é crucial em ambiente híbrido.

---

# 🚨 Parte 3 – Alertas de Performance

Aqui entra a “operacionalização”.

## Tipos de alertas úteis em híbrido:

### Métricas (rápidos)

* CPU
* Memória
* Disco

### Logs/KQL (inteligentes)

* Falta de ingestão (sinal de agente quebrado)
* Reboots inesperados
* Erros específicos

Pergunta estratégica:

> Vocês preferem alertar “CPU alta” ou “serviço indisponível”?

A segunda é mais madura.

---

# 🛠️ Hands-on 2 – Criando Alertas Reais

1. Criar um alerta de métrica para performance
2. Criar um alerta KQL (ex.: servidor sem logs por X minutos)
3. Vincular Action Group
4. Definir severidade

> 💡 Se a empresa sofre com ruído, aqui você implementa “severidade por impacto”.

---

# 🧩 Parte 4 – Centralização de Métricas e Logs

Esse bloco é estratégico.

Perguntas para fechar:

1. Workspace único ou múltiplos?
2. Segmentação por ambiente (dev/hml/prod)?
3. Segmentação por domínio (apps vs infra)?
4. Retenção padrão? exceções?
5. O que deve ser obrigatório? o que é opcional?

Você pode anotar decisões e já preencher o documento final.

---

# ✅ Conclusão da Sessão

Nesta sessão, consolidamos:

* DCR avançadas como base de governança.
* KQL como ferramenta operacional (não “linguagem de BI”).
* Alertas reais que evitam ruído.
* Estratégia de centralização de logs e métricas para ambiente híbrido.

Na próxima sessão, vamos transformar tudo isso em:

> Dashboards e Workbooks por perfil (Application Owner vs IT Ops / SRE)

---

# 🎯 Resultado Esperado da Sessão 8

Ao final desta sessão:

* A empresa tem um modelo de DCR padronizável.
* O grupo sabe validar ingestão e saúde do agente.
* Alertas começam a ser organizados por impacto.
* A centralização de dados vira decisão arquitetural (não improviso).