namespace func_monitor.Functions;public class FunctionHttpHealth
{
    private readonly ILogger<FunctionHttpHealth> _logger;    public FunctionHttpHealth(ILogger<FunctionHttpHealth> logger)
    {
        _logger = logger;
    }    [Function("healthy")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}