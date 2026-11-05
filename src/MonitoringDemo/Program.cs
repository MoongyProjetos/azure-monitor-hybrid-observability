
using Azure.Monitor.OpenTelemetry.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Application Insights via OpenTelemetry
builder.Services
    .AddOpenTelemetry()
    .UseAzureMonitor();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation("Hello World endpoint was called.");

    return Results.Ok(new
    {
        Message = "Hello from AKS!",
        Application = "MonitoringDemo",
        Version = "1.0.0",
        Timestamp = DateTime.UtcNow
    });
});

app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy"
}));

app.MapGet("/error", (ILogger<Program> logger) =>
{
    logger.LogError("Simulated application error!");

    throw new InvalidOperationException(
        "This is a simulated exception for monitoring.");
});

app.Run();
