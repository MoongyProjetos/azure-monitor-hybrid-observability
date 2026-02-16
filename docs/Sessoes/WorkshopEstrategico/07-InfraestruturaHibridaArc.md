# 📘 Sessão 7 – Infraestrutura Híbrida e Azure Arc

---

## 🎯 Objetivos da Sessão

* Compreender o papel do Azure Arc na estratégia híbrida.
* Integrar servidores on-premises ao Azure.
* Aplicar Azure Monitor Agent em ambiente híbrido.
* Definir padrão organizacional de agentes e coleta.
* Consolidar modelo unificado de observabilidade.

---

# 🌍 Parte 1 – O Desafio da Hibridização

Pergunta inicial:

> Hoje vocês têm visibilidade unificada entre cloud e on-prem?

Problema comum:

* Azure monitorado
* On-prem isolado
* Ferramentas diferentes
* Padrões diferentes
* Governança fragmentada

Isso gera:

* Visão parcial
* Falhas silenciosas
* Duplicidade de ferramenta

---

# 🧭 Conceitos de Azure Arc

Azure Arc permite:

* Registrar servidores on-premises no Azure
* Aplicar políticas
* Aplicar Azure Monitor Agent
* Unificar gestão e monitoramento

Ele transforma:

Servidor físico ou VM on-prem
em
Recurso gerenciado no Azure.

---

## Modelo Conceitual

```
Servidor On-Prem → Azure Arc → Azure Monitor Agent → DCR → Log Analytics
```

Isso elimina:

* Diferença entre cloud e on-prem
* Modelo de agente diferente
* Governança descentralizada

---

# 🛠️ Onboarding de Servidores On-Premises

Processo:

1. Registrar servidor no Azure Arc
2. Instalar Azure Monitor Agent
3. Associar Data Collection Rule
4. Validar ingestão de dados

Pergunta estratégica:

> Todos os servidores precisam ser integrados ou só os críticos?

---

# 🟢 Azure Monitor Agent em Ambiente Híbrido

Aqui você reforça o padrão:

Se já definimos AMA como padrão na cloud…

Ele também deve ser padrão no on-prem.

Isso evita:

* Dois modelos de coleta
* Dois padrões de alerta
* Dois modelos de retenção

---

# 🧠 Estratégia Moderna de Agentes

Momento arquitetural da sessão.

Você conduz perguntas como:

1. Vamos padronizar AMA como único agente?
2. Vamos centralizar DCR?
3. Vamos usar workspace único?
4. Vamos segmentar por ambiente?
5. Vamos definir retenção padrão?

Esse é o momento onde você começa a desenhar o modelo oficial.

---

# 🛠️ Hands-on Estratégico

Se tiver ambiente disponível:

* Registrar uma VM via Arc
* Aplicar AMA
* Associar DCR
* Consultar logs no workspace

Se não tiver:

* Demonstração guiada
* Simulação arquitetural
* Discussão estratégica

---

# 📊 Consolidação da Arquitetura Unificada

Você pode desenhar algo assim:

```
Aplicações → App Insights
Containers → Container Insights
Infra Cloud → AMA + DCR
Infra On-Prem → Arc + AMA + DCR
Logs → Log Analytics
Alertas → Azure Monitor
Dashboards → Workbooks
```

Isso é modelo completo.

---

# 🧩 Discussão Estratégica (15 min)

Perguntas fundamentais:

1. Hoje há diferença entre monitoramento cloud e on-prem?
2. Existe ferramenta diferente para on-prem?
3. Existe duplicidade de custo?
4. Existe governança formal de coleta?
5. Existe padrão mínimo por tipo de servidor?

Aqui você praticamente fecha a seção de Arquitetura no documento estratégico.

---

# 🧠 Conexão com Sessão 8

Agora que já temos:

* Modelo unificado
* Agente padronizado
* DCR como política
* Infra cloud e híbrida integradas

Na próxima sessão vamos aprofundar:

> Logs e alertas avançados em ambientes híbridos.

---

# 🎯 Resultado Esperado da Sessão 7

Ao final desta sessão:

* A empresa entende como unificar monitoramento.
* AMA passa a ser visto como padrão único.
* Azure Arc deixa de ser “extra” e vira peça estratégica.
* O modelo híbrido começa a ganhar forma oficial.

