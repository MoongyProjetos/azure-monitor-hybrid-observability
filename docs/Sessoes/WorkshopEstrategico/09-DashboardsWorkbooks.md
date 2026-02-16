# 📘 Sessão 9 – Dashboards e Workbooks por Perfil

---

## 🎯 Objetivos da Sessão

* Diferenciar dashboards operacionais de dashboards estratégicos.
* Criar visões específicas para Application Owners.
* Criar visões operacionais para IT Ops / SRE.
* Aplicar boas práticas de visualização.
* Formalizar modelo de visualização por persona na organização.

---

# 🧠 Parte 1 – Por que Dashboards por Perfil?

Pergunta inicial:

> Hoje todos enxergam o mesmo dashboard?

Problema comum:

* Dashboard único para tudo
* Informações demais
* Falta de foco
* Falta de responsabilidade

Visualização correta não é técnica.
É organizacional.

---

# 👤 Persona 1 – Application Owners

Application Owner quer responder:

* A aplicação está saudável?
* O usuário está sendo impactado?
* Existe degradação?
* Estamos cumprindo SLA?

---

## 📊 Dashboard para Application Owners

Deve conter:

* SLA / Disponibilidade
* Taxa de erro
* Latência média
* Apdex (se aplicável)
* Volume de requisições
* Incidentes recentes

Não deve conter:

* CPU de node
* Métricas técnicas profundas
* Logs brutos

> Foco em impacto no negócio.

---

# 🛠️ Hands-on 1 – Criar Workbook para Application Owner

Componentes recomendados:

* Gráfico de disponibilidade
* Percentual de erro por intervalo
* Latência média
* Requests por minuto
* Mapa de dependências (Application Map)

Pergunta estratégica:

> Esse dashboard permitiria ao dono da aplicação tomar decisão rápida?

---

# 👷 Persona 2 – IT Ops / SRE

IT Ops quer responder:

* Infra está saudável?
* Existe risco de capacidade?
* Existe alerta ativo?
* Algum agente parou de enviar logs?

---

## 📊 Dashboard para IT Ops / SRE

Deve conter:

* Saúde de infraestrutura
* Uso de CPU / Memória
* Status de nodes AKS
* Restart de containers
* Alertas ativos
* Tendência de consumo

---

# 🛠️ Hands-on 2 – Criar Workbook Operacional

Componentes recomendados:

* Lista de alertas ativos
* CPU média por VM
* Uso de memória
* Restart count em AKS
* Tendência de ingestão de logs

Pergunta estratégica:

> Esse dashboard ajuda a prevenir incidente ou só reagir?

---

# 📘 Workbooks vs Dashboards

## Dashboards

* Visão rápida
* Mais simples
* Ideal para painel contínuo

## Workbooks

* Interativos
* Consultas avançadas
* Filtros dinâmicos
* Personalização por ambiente

> Workbooks são ferramenta estratégica.
> Dashboards são ferramenta operacional.

---

# 🎨 Boas Práticas de Visualização

### 1️⃣ Menos é mais

Evitar excesso de gráficos.

### 2️⃣ Começar pelo que dói

Primeiro indicadores críticos.

### 3️⃣ Hierarquia clara

Crítico → Alto → Médio → Informativo

### 4️⃣ Nomeação padronizada

Exemplo:

* WB-APP-Prod-Health
* WB-Ops-Infra-Overview

### 5️⃣ Separação por ambiente

Dev ≠ Produção

---

# 🧩 Discussão Estratégica (15 min)

Perguntas importantes:

1. Quem é dono do dashboard?
2. Quem mantém?
3. Existe revisão periódica?
4. Dashboard substitui alerta?
5. Existe visão executiva necessária?

Aqui você começa a fechar:

Seção de Visualização do documento estratégico.

---

# 🔗 Conexão com Sessão 10

Agora que temos:

* Coleta padronizada
* Alertas inteligentes
* Monitoramento de apps, dados e containers
* Dashboards por perfil

Falta fechar:

> Integrações, custos e governança.

---

# 🎯 Resultado Esperado da Sessão 9

Ao final desta sessão:

* A empresa tem modelo claro de visualização por persona.
* Dashboards deixam de ser genéricos.
* Responsabilidade começa a ser definida.
* Observabilidade começa a virar cultura, não só ferramenta.
