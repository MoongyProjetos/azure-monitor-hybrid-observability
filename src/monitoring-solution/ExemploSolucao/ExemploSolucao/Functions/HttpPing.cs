using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ExemploSolucao.Functions;

public class HttpPing
{
    private readonly ILogger<HttpPing> _logger;

    public HttpPing(ILogger<HttpPing> logger)
    {
        _logger = logger;
    }

    [Function("HttpPing")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}