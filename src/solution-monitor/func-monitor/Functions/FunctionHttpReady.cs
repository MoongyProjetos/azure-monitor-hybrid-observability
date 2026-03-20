namespace func_monitor.Functions;public class FunctionHttpReady
{
    private readonly ILogger<FunctionHttpReady> _logger;
    private readonly AdventureWorksDBContext _context;    public FunctionHttpReady(ILogger<FunctionHttpReady> logger, AdventureWorksDBContext context)
    {
        _logger = logger;
        _context = context;
    }    [Function("ready")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        var count = _context.ProductModels.Count();
        if(count > 0)
        {
            _logger.LogInformation("Database connection successful. ProductModels count: {count}", count);
            return new OkObjectResult("Welcome to Azure Functions!");
        }        return new NotFoundResult();
    }
}