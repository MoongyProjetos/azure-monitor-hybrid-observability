namespace func_monitor.Functions;public class FunctionHttpObterModelos
{
    private readonly ILogger<FunctionHttpObterModelos> _logger;
    private readonly AdventureWorksDBContext _context;    public FunctionHttpObterModelos(ILogger<FunctionHttpObterModelos> logger, AdventureWorksDBContext context)
    {
        _logger = logger;
        _context = context;
    }    [Function("ObterModelos")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");        var dados = _context.ProductModels.OrderByDescending(x => x.ModifiedDate)
        .Select(x => new
            {
                x.ProductModelId,
                x.Name,
                x.CatalogDescription,
                x.ModifiedDate
            })
        .Take(100).ToList();        return new OkObjectResult(dados);
    }
}