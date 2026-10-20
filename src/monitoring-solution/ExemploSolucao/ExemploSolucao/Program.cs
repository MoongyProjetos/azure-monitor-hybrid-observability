
using Azure.Monitor.OpenTelemetry.Exporter;
using ExemploSolucao.Models;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

if (!string.IsNullOrEmpty(
    Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
{
    builder.Services.AddOpenTelemetry()
        .UseFunctionsWorkerDefaults()
        .UseAzureMonitorExporter();
}

// SQL Server / Entity Framework Core
var connectionString =
    builder.Configuration.GetConnectionString("DatabaseConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DatabaseConnection' não configurada.");

builder.Services.AddDbContextFactory<SqldbMonitorJnPrdContext>(
    options => options.UseSqlServer(connectionString));

builder.Build().Run();
