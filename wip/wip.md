Key Components of an Azure Monitoring Strategy
Infrastructure & Platform Monitoring: Monitor virtual machines, containers, and databases using Azure Monitor Metrics (time-series data) and diagnostic logs for visibility.
Application Performance Management (APM): Use Application Insights to detect performance anomalies, application map dependencies, and user behavior in live applications.
Centralized Log Analytics: Utilize Log Analytics workspaces to collect, aggregate, and query data from various sources using KQL for in-depth troubleshooting.
Proactive Alerting & Action Groups: Configure alerts on metrics or log queries to notify administrators or trigger automated responses (Logic Apps, Automation Runbooks) to resolve issues.
Visualization and Dashboards: Use Azure Dashboards and Workbooks to create interactive reports that combine data from multiple sources for actionable insights. 



Best Practices for Implementation
Comprehensive Coverage: Enable diagnostics for all relevant components, including the control plane (Activity Logs).
Scale with Automation: Use Azure Policy, Terraform, or ARM templates to deploy monitoring configurations at scale.
Centralize Governance: Implement a dedicated monitoring subscription or shared resource group for managing workspaces and alerts.
Define KPIs: Align monitoring with business objectives and define clear baselines for performance.
Optimize Costs: Configure data sampling in Application Insights and manage log retention periods to keep costs low. 



Links úteis:
https://www.youtube.com/watch?v=XN4A-jNZ5Tk&t=63s





...

https://www.youtube.com/watch?v=XN4A-jNZ5Tk&t=63s




![alt text](image.png)


##Core Components:

Metrics
Logs
Alerts
Workbooks


## Data Collection Sources

![alt text](image-1.png)


- Azure Resources
- Applications
- Guest OS & VMs
- On Premises


![alt text](image-2.png)


![alt text](image-3.png)







...

https://www.youtube.com/watch?v=XN4A-jNZ5Tk&t=63s




![alt text](image.png)


##Core Components:

Metrics
Logs
Alerts
Workbooks


## Data Collection Sources

![alt text](image-1.png)


- Azure Resources
- Applications
- Guest OS & VMs
- On Premises


![alt text](image-2.png)


![alt text](image-3.png)

![alt text](image-4.png)



Falar com Dinis:
Necessidade de subscricao de treino para todos
Provisionamento de VM training



---
Labs: 
- Script para criacao (bicep?)
- Diagramas
- Melhorar labs com versão mais passo a passo
- passar perguntas do Lab para o Google Forms
