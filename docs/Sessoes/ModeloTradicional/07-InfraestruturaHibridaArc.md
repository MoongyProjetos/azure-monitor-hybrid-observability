# 📘 Sessão 7 – Infraestrutura Híbrida e Azure Arc

## 🎯 Objetivos da Sessão

* Compreender o conceito e o papel do Azure Arc em ambientes híbridos.
* Integrar servidores on-premises ao Azure.
* Implantar Azure Monitor Agent (AMA) em máquinas híbridas.
* Definir uma estratégia moderna de agentes em ambientes distribuídos.

---

## 🌐 Desafio da Observabilidade Híbrida

Ambientes corporativos raramente são apenas cloud.

Cenário típico:

* Servidores on-premises
* VMs em múltiplas clouds
* Containers
* Recursos Azure

Desafios:

* Visibilidade fragmentada
* Ferramentas distintas
* Configuração inconsistente
* Governança limitada

Perguntas comuns:

* Como monitorar on-premises no Azure?
* Como padronizar agentes?
* Como centralizar logs?
* Como aplicar políticas?

---

## 🧭 O que é Azure Arc?

Azure Arc estende o controle do Azure para recursos fora do Azure.

Permite gerenciar no Azure:

* Servidores on-premises
* VMs em outras clouds
* Kubernetes externos
* SQL fora do Azure

Na prática:

👉 recursos híbridos aparecem como recursos Azure

---

## 🧱 Arquitetura do Azure Arc para Servidores

Fluxo simplificado:

Servidor on-premises
→ Arc agent
→ Azure Resource Manager
→ Azure Monitor / Policy / Defender

O servidor passa a ter:

* Resource ID Azure
* Tags
* RBAC
* Policy
* Monitoramento

---

## 🔗 Onboarding de Servidores On-Premises

Processo de integração:

1. Registrar servidor no Azure Arc
2. Instalar Arc agent
3. Conectar ao tenant/subscription
4. Validar no portal

Após onboarding:

Servidor aparece em:

Azure → **Azure Arc → Servers**

---

## 📊 Monitoramento Híbrido com AMA

Após o servidor estar no Arc:

Pode receber:

* Azure Monitor Agent
* Data Collection Rules
* Policy
* Extensions

Fluxo:

Servidor Arc
→ AMA
→ Log Analytics
→ Azure Monitor

---

## 🚀 Azure Monitor Agent em Ambientes Híbridos

O AMA é o agente unificado para:

* VMs Azure
* Servidores Arc
* Ambientes híbridos

Benefícios:

* Configuração centralizada
* Reutilização de DCR
* Escala
* Consistência
* Governança

---

## 🧭 Estratégia Moderna de Agentes

Abordagem recomendada:

**1️⃣ Padronizar AMA**
Substituir agentes legados

**2️⃣ Centralizar via DCR**
Configuração reutilizável

**3️⃣ Associar por escopo**
Subscription / RG / Tag

**4️⃣ Governança via Policy**
Implantação automática

---

## 🧠 Boas Práticas em Ambientes Híbridos

* Usar Arc como camada de controle
* Padronizar AMA em todos os servidores
* Separar DCR por tipo de workload
* Usar tags para associação
* Centralizar em Log Analytics
* Automatizar via Policy

> 💡 Azure Arc transforma servidores externos em recursos nativos do Azure.

---

## 🧭 Casos de Uso do Azure Arc + Monitor

* Monitorar datacenter on-premises
* Unificar visibilidade multi-cloud
* Aplicar políticas de segurança
* Coletar logs centralizados
* Monitorar legado fora do Azure

---

## ✅ Conclusão da Sessão

Nesta sessão, você aprendeu:

* O papel do Azure Arc em ambientes híbridos.
* Como integrar servidores on-premises ao Azure.
* Uso do Azure Monitor Agent em híbrido.
* Estratégias modernas de agentes.
* Governança e monitoramento unificado.

Na próxima sessão, vamos aplicar esses conceitos na **centralização de logs e alertas em ambientes híbridos**.

---

> © MoOngy 2026 | Programa de formação em Observabilidade com Azure Monitor
