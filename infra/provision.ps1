<# 
Workshop Observabilidade - Provisionamento de Infra (Azure Cloud Shell - PowerShell)

Cria:
- RG, Log Analytics Workspace, App Insights
- Storage, SQL Server+DB, App Service Plan+Web App
- Action Group + Alertas (métricas)
- DCRs (JSON) + Associações (opcional a VM)
- AKS + ACR (opcional)
- ACI (opcional)

Requisitos:
- Rodar no Azure Cloud Shell (PowerShell) com permissões Contributor/Owner na subscription.
#>

$ErrorActionPreference = "Stop"

# =========================
# 0) CONFIGURAÇÕES
# =========================
$prefix          = "obsws"                 # <-- troque (de preferência algo único)
$location        = "westeurope"            # <-- ajuste (ex: "eastus", "brazilsouth")
$rgName          = "rg-$prefix-workshop"
$lawName         = "law-$prefix"
$appInsightsName = "appi-$prefix"
$storageName     = ("st" + $prefix + (Get-Random -Maximum 9999)).ToLower()  # storage precisa ser globalmente único
$sqlServerName   = ("sql-" + $prefix + "-" + (Get-Random -Maximum 9999)).ToLower()
$sqlDbName       = "sqldb-$prefix"
$appServicePlan  = "asp-$prefix"
$webAppName      = ("web-" + $prefix + "-" + (Get-Random -Maximum 9999)).ToLower()

# SQL Admin (NUNCA use senha real em repositório)
$sqlAdminUser    = "sqladminuser"
# Gere uma senha forte. Você pode trocar por Read-Host -AsSecureString se preferir.
$sqlAdminPwdPlain = "P@ssw0rd!ChangeMe1234"  # <-- TROQUE
$sqlAdminPwd     = ConvertTo-SecureString $sqlAdminPwdPlain -AsPlainText -Force
$sqlCred         = New-Object System.Management.Automation.PSCredential($sqlAdminUser, $sqlAdminPwd)

# Action Group
$actionGroupName = "ag-$prefix-ops"
$shortName       = "ops$($prefix.Substring(0,[Math]::Min(4,$prefix.Length)))"
$notifyEmail     = "seu-email@empresa.com"   # <-- TROQUE

# Flags (AKS/ACR são caros/demorados)
$createAksAcr    = $false     # <-- mude pra $true se quiser AKS + ACR
$createAci       = $true      # ACI é mais leve
$createVmForAma  = $false     # <-- se quiser criar uma VM só pra associar DCR/AMA (custo extra)

# =========================
# 1) GARANTIR MÓDULOS
# =========================
# Cloud Shell normalmente já tem Az.*. Ainda assim, garantimos os módulos principais.
$modules = @("Az.Accounts","Az.Resources","Az.OperationalInsights","Az.Monitor","Az.ApplicationInsights","Az.Storage","Az.Sql","Az.Websites","Az.ContainerInstance","Az.ContainerRegistry","Az.Aks")
foreach ($m in $modules) {
  if (-not (Get-Module -ListAvailable -Name $m)) {
    Write-Host "Instalando módulo $m ..."
    Install-Module $m -Scope CurrentUser -Force -AllowClobber
  }
}

# =========================
# 2) CONTEXTO DA SUBSCRIPTION
# =========================
$ctx = Get-AzContext
if (-not $ctx) { 
  Connect-AzAccount | Out-Null
  $ctx = Get-AzContext
}
Write-Host "Subscription: $($ctx.Subscription.Name) ($($ctx.Subscription.Id))"
$subId = $ctx.Subscription.Id

# =========================
# 3) RESOURCE GROUP
# =========================
Write-Host "`n==> Criando Resource Group: $rgName"
New-AzResourceGroup -Name $rgName -Location $location -Force | Out-Null

# =========================
# 4) LOG ANALYTICS WORKSPACE
# =========================
Write-Host "`n==> Criando Log Analytics Workspace: $lawName"
$law = New-AzOperationalInsightsWorkspace `
  -ResourceGroupName $rgName `
  -Name $lawName `
  -Location $location `
  -Sku "PerGB2018" | Out-Null

$law = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $lawName
Write-Host "LAW Id: $($law.ResourceId)"

# =========================
# 5) APPLICATION INSIGHTS (workspace-based)
# =========================
Write-Host "`n==> Criando Application Insights (workspace-based): $appInsightsName"
# Workspace-based: vincula ao Log Analytics via -WorkspaceResourceId
New-AzApplicationInsights `
  -ResourceGroupName $rgName `
  -Name $appInsightsName `
  -Location $location `
  -Kind "web" `
  -ApplicationType "web" `
  -WorkspaceResourceId $law.ResourceId | Out-Null

$appInsights = Get-AzApplicationInsights -ResourceGroupName $rgName -Name $appInsightsName
Write-Host "AppInsights Id: $($appInsights.Id)"

# =========================
# 6) STORAGE ACCOUNT
# =========================
Write-Host "`n==> Criando Storage Account: $storageName"
New-AzStorageAccount `
  -ResourceGroupName $rgName `
  -Name $storageName `
  -Location $location `
  -SkuName Standard_LRS `
  -Kind StorageV2 `
  -EnableHttpsTrafficOnly $true | Out-Null

$st = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageName
Write-Host "Storage Id: $($st.Id)"

# =========================
# 7) SQL SERVER + DATABASE
# =========================
Write-Host "`n==> Criando Azure SQL Server: $sqlServerName"
New-AzSqlServer `
  -ResourceGroupName $rgName `
  -ServerName $sqlServerName `
  -Location $location `
  -SqlAdministratorCredentials $sqlCred | Out-Null

Write-Host "`n==> Criando regra de firewall (0.0.0.0) para permitir Azure services (opcional)"
New-AzSqlServerFirewallRule `
  -ResourceGroupName $rgName `
  -ServerName $sqlServerName `
  -FirewallRuleName "AllowAzureServices" `
  -StartIpAddress "0.0.0.0" `
  -EndIpAddress "0.0.0.0" | Out-Null

Write-Host "`n==> Criando Database: $sqlDbName"
New-AzSqlDatabase `
  -ResourceGroupName $rgName `
  -ServerName $sqlServerName `
  -DatabaseName $sqlDbName `
  -Edition "GeneralPurpose" `
  -Vcore 2 `
  -ComputeGeneration "Gen5" | Out-Null

# =========================
# 8) APP SERVICE PLAN + WEB APP
# =========================
Write-Host "`n==> Criando App Service Plan: $appServicePlan"
New-AzAppServicePlan `
  -ResourceGroupName $rgName `
  -Location $location `
  -Name $appServicePlan `
  -Tier "Basic" `
  -WorkerSize "Small" | Out-Null

Write-Host "`n==> Criando Web App: $webAppName"
New-AzWebApp `
  -ResourceGroupName $rgName `
  -Location $location `
  -Name $webAppName `
  -AppServicePlan $appServicePlan | Out-Null

# (Opcional) Vínculo com App Insights via app settings
Write-Host "`n==> Configurando App Settings para App Insights (instrumentation key / connection string)"
$appInsightsConn = (Get-AzApplicationInsights -ResourceGroupName $rgName -Name $appInsightsName).ConnectionString
Set-AzWebApp `
  -ResourceGroupName $rgName `
  -Name $webAppName `
  -AppSettings @{ "APPLICATIONINSIGHTS_CONNECTION_STRING" = $appInsightsConn } | Out-Null

# =========================
# 9) ACTION GROUP (E-MAIL)
# =========================
Write-Host "`n==> Criando Action Group: $actionGroupName"
$emailReceiver = New-AzActionGroupEmailReceiverObject -Name "email1" -EmailAddress $notifyEmail -UseCommonAlertSchema
$ag = Set-AzActionGroup `
  -ResourceGroupName $rgName `
  -Name $actionGroupName `
  -ShortName $shortName `
  -Receiver $emailReceiver | Out-Null

$ag = Get-AzActionGroup -ResourceGroupName $rgName -Name $actionGroupName
Write-Host "ActionGroup Id: $($ag.Id)"

# =========================
# 10) ALERTAS (MÉTRICAS) - EXEMPLOS
# =========================
Write-Host "`n==> Criando alerta de métrica (WebApp - HTTP 5xx > 0)"
# Critério de alerta V2
$criteria = New-AzMetricAlertRuleV2Criteria `
  -MetricName "Http5xx" `
  -TimeAggregation Total `
  -Operator GreaterThan `
  -Threshold 0

Add-AzMetricAlertRuleV2 `
  -Name "alert-$prefix-webapp-http5xx" `
  -ResourceGroupName $rgName `
  -WindowSize (New-TimeSpan -Minutes 5) `
  -Frequency (New-TimeSpan -Minutes 1) `
  -TargetResourceId (Get-AzWebApp -ResourceGroupName $rgName -Name $webAppName).Id `
  -Condition $criteria `
  -ActionGroupId $ag.Id `
  -Severity 2 `
  -Description "Dispara quando ocorrerem erros HTTP 5xx no Web App." | Out-Null

# =========================
# 11) DCRs (DATA COLLECTION RULES) + ASSOCIATIONS
# =========================
Write-Host "`n==> Criando DCRs (via JSON) - padrão base e crítico"

# Caminhos temporários
$tmp = "$HOME/dcr"
New-Item -ItemType Directory -Force -Path $tmp | Out-Null

# Observação:
# - DCRs variam por tipo de fonte. Aqui criamos um exemplo genérico (Perf + EventLog).
# - Ajuste conforme sua realidade (Windows/Linux, counters, event logs, etc.).
$dcrBaseJsonPath    = Join-Path $tmp "dcr-base-windows.json"
$dcrCriticalJsonPath = Join-Path $tmp "dcr-critical-infra.json"

# DCR Base (Windows) - Perf + Event Logs básicos
@"
{
  "location": "$location",
  "properties": {
    "dataSources": {
      "performanceCounters": [
        {
          "name": "perfBase",
          "streams": [ "Microsoft-Perf" ],
          "samplingFrequencyInSeconds": 60,
          "counterSpecifiers": [
            "\\\\Processor(_Total)\\\\% Processor Time",
            "\\\\Memory\\\\Available MBytes",
            "\\\\LogicalDisk(_Total)\\\\% Free Space"
          ]
        }
      ],
      "windowsEventLogs": [
        {
          "name": "eventBase",
          "streams": [ "Microsoft-WindowsEvent" ],
          "xPathQueries": [
            "Application!*[System[(Level=1 or Level=2)]]",
            "System!*[System[(Level=1 or Level=2)]]"
          ]
        }
      ]
    },
    "destinations": {
      "logAnalytics": [
        {
          "name": "dest-law",
          "workspaceResourceId": "$($law.ResourceId)"
        }
      ]
    },
    "dataFlows": [
      {
        "streams": [ "Microsoft-Perf", "Microsoft-WindowsEvent" ],
        "destinations": [ "dest-law" ]
      }
    ]
  }
}
"@ | Set-Content -Path $dcrBaseJsonPath -Encoding utf8

# DCR Crítica (infra) - mais granularidade (exemplo simples)
@"
{
  "location": "$location",
  "properties": {
    "dataSources": {
      "performanceCounters": [
        {
          "name": "perfCritical",
          "streams": [ "Microsoft-Perf" ],
          "samplingFrequencyInSeconds": 30,
          "counterSpecifiers": [
            "\\\\Processor(_Total)\\\\% Processor Time",
            "\\\\Memory\\\\% Committed Bytes In Use",
            "\\\\LogicalDisk(_Total)\\\\Avg. Disk sec/Transfer",
            "\\\\LogicalDisk(_Total)\\\\% Free Space"
          ]
        }
      ],
      "windowsEventLogs": [
        {
          "name": "eventCritical",
          "streams": [ "Microsoft-WindowsEvent" ],
          "xPathQueries": [
            "Application!*[System[(Level=1 or Level=2 or Level=3)]]",
            "System!*[System[(Level=1 or Level=2 or Level=3)]]"
          ]
        }
      ]
    },
    "destinations": {
      "logAnalytics": [
        {
          "name": "dest-law",
          "workspaceResourceId": "$($law.ResourceId)"
        }
      ]
    },
    "dataFlows": [
      {
        "streams": [ "Microsoft-Perf", "Microsoft-WindowsEvent" ],
        "destinations": [ "dest-law" ]
      }
    ]
  }
}
"@ | Set-Content -Path $dcrCriticalJsonPath -Encoding utf8

# Criar DCRs
New-AzDataCollectionRule -ResourceGroupName $rgName -Name "dcr-$prefix-base-windows" -JsonFilePath $dcrBaseJsonPath | Out-Null
New-AzDataCollectionRule -ResourceGroupName $rgName -Name "dcr-$prefix-critical-infra" -JsonFilePath $dcrCriticalJsonPath | Out-Null

$dcrBase    = Get-AzDataCollectionRule -ResourceGroupName $rgName -Name "dcr-$prefix-base-windows"
$dcrCritical = Get-AzDataCollectionRule -ResourceGroupName $rgName -Name "dcr-$prefix-critical-infra"
Write-Host "DCR Base Id: $($dcrBase.Id)"
Write-Host "DCR Critical Id: $($dcrCritical.Id)"

# (Opcional) criar VM para testar AMA + associar DCR (custo)
if ($createVmForAma) {
  Write-Host "`n==> Criando VM para testes de AMA/DCR (opcional)"
  $vmName = "vm-$prefix-ama"
  $vnetName = "vnet-$prefix"
  $subnetName = "snet-$prefix"
  $nsgName = "nsg-$prefix"

  $secureVmPwd = ConvertTo-SecureString "P@ssw0rd!ChangeMe9876" -AsPlainText -Force
  $vmCred = New-Object System.Management.Automation.PSCredential("azureuser", $secureVmPwd)

  $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.10.1.0/24"
  $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix "10.10.0.0/16" -Subnet $subnetConfig
  $nsg = New-AzNetworkSecurityGroup -Name $nsgName -ResourceGroupName $rgName -Location $location
  $pip = New-AzPublicIpAddress -Name "pip-$prefix" -ResourceGroupName $rgName -Location $location -AllocationMethod Static
  $nic = New-AzNetworkInterface -Name "nic-$prefix" -ResourceGroupName $rgName -Location $location -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id

  $vmConfig = New-AzVMConfig -VMName $vmName -VMSize "Standard_B2s" |
    Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $vmCred -ProvisionVMAgent -EnableAutoUpdate |
    Set-AzVMSourceImage -PublisherName "MicrosoftWindowsServer" -Offer "WindowsServer" -Skus "2022-datacenter-azure-edition" -Version "latest" |
    Add-AzVMNetworkInterface -Id $nic.Id

  New-AzVM -ResourceGroupName $rgName -Location $location -VM $vmConfig | Out-Null
  $vm = Get-AzVM -ResourceGroupName $rgName -Name $vmName
  Write-Host "VM criada: $vmName"

  # Instalar AMA (extensão) e associar DCR Base
  Write-Host "`n==> Instalando Azure Monitor Agent na VM e associando DCR Base"
  # Extensão AMA (nome pode variar por OS/versão do agent); aqui usamos Set-AzVMExtension com publisher Microsoft.Azure.Monitor
  Set-AzVMExtension `
    -ResourceGroupName $rgName `
    -VMName $vmName `
    -Name "AzureMonitorWindowsAgent" `
    -Publisher "Microsoft.Azure.Monitor" `
    -ExtensionType "AzureMonitorWindowsAgent" `
    -TypeHandlerVersion "1.0" `
    -Location $location | Out-Null

  New-AzDataCollectionRuleAssociation `
    -Name "assoc-$($dcrBase.Name)" `
    -ResourceGroupName $rgName `
    -RuleId $dcrBase.Id `
    -TargetResourceId $vm.Id | Out-Null
}

# =========================
# 12) AKS + ACR (OPCIONAL)
# =========================
if ($createAksAcr) {
  Write-Host "`n==> Criando ACR + AKS (opcional)"
  $acrName = ("acr" + $prefix + (Get-Random -Maximum 9999)).ToLower()
  $aksName = "aks-$prefix"

  New-AzContainerRegistry -ResourceGroupName $rgName -Name $acrName -Sku Standard -Location $location | Out-Null

  # AKS básico (1 node). Observação: AKS pode demorar e custar.
  New-AzAksCluster -ResourceGroupName $rgName -Name $aksName -Location $location -NodeCount 1 -NodeVmSize "Standard_B2s" -KubernetesVersion "" | Out-Null

  Write-Host "AKS: $aksName | ACR: $acrName"
}

# =========================
# 13) ACI (OPCIONAL)
# =========================
if ($createAci) {
  Write-Host "`n==> Criando Azure Container Instance (opcional)"
  $aciName = "aci-$prefix"
  $dnsName = ("dns" + $prefix + (Get-Random -Maximum 9999)).ToLower()

  New-AzContainerGroup `
    -ResourceGroupName $rgName `
    -Name $aciName `
    -Location $location `
    -Image "mcr.microsoft.com/azuredocs/aci-helloworld:latest" `
    -OsType Linux `
    -IpAddressType Public `
    -DnsNameLabel $dnsName `
    -Port 80 | Out-Null

  Write-Host "ACI criado: $aciName (DNS: $dnsName)"
}

# =========================
# 14) PRÓXIMOS PASSOS – AZURE ARC (MANUAL)
# =========================
Write-Host "`n==============================="
Write-Host "Provisionamento concluído ✅"
Write-Host "RG: $rgName"
Write-Host "LAW: $lawName"
Write-Host "AppInsights: $appInsightsName"
Write-Host "WebApp: https://$webAppName.azurewebsites.net"
Write-Host ""
Write-Host "Azure Arc (On-Prem):"
Write-Host " - Vá em Azure Arc > Servers > Add"
Write-Host " - Gere o script e execute no servidor on-prem/VM"
Write-Host " - Depois instale AMA e associe uma DCR (dcr-$prefix-base-windows ou dcr-$prefix-critical-infra)"
Write-Host "==============================="
 