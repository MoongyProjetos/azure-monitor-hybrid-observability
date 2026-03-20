namespace func_monitor.Functions;public class FunctionEventhubCriarModeloNovo
{
    private readonly ILogger<FunctionEventhubCriarModeloNovo> _logger;
    private readonly AdventureWorksDBContext _context;    public FunctionEventhubCriarModeloNovo(ILogger<FunctionEventhubCriarModeloNovo> logger, AdventureWorksDBContext context)
    {
        _logger = logger;
        _context = context;
    }    [Function(nameof(FunctionEventhubCriarModeloNovo))]
    public void Run([EventHubTrigger("produtos", Connection = "EventHubConnectionString")] EventData[] events)
    {
        foreach (EventData @event in events)
        {
            _logger.LogInformation("Event Body: {body}", @event.Body);
            _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);            var id = Guid.NewGuid(); // Gerar um ID único para cada evento recebido, para evitar duplicatas.
            SaveToDatabase(@event, id);
            _context.SaveChanges();            SaveToBlobStorage(@event, id);
        }
    }    /// <summary>
    /// Implementação para salvar o evento no Database. 
    /// O conteúdo do blob será o JSON do evento recebido, juntamente com a data e hora de recebimento.
    /// </summary>
    /// <param name="event"></param>
    private void SaveToDatabase(EventData @event, Guid id)
    {
        JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
        var options = jsonSerializerOptions;
        var json = Encoding.UTF8.GetString(@event.Body.ToArray());
        var produtoModel = JsonSerializer.Deserialize<ProductModel>(json, options);        if (produtoModel != null)
        {
            //Para evitar duplicatas, vamos adicionar a data e hora de recebimento ao nome do modelo.
            //Assim, mesmo que o mesmo produto seja recebido várias vezes, ele será registrado como um novo modelo no banco de dados.
            produtoModel.Name = $"{produtoModel.Name}-{id}"[..50];
            _context.ProductModels.Add(produtoModel);
        }
    }
    /// <summary>
    /// Implementação para salvar o evento no Blob Storage. O conteúdo do blob será o JSON do evento recebido, juntamente com a data e hora de recebimento.
    /// </summary>
    /// <param name="event"></param>
    private void SaveToBlobStorage(EventData @event, Guid id)
    {
        var sasUrl = Environment.GetEnvironmentVariable("BlobContainerSasUrl");
        var containerClient = new BlobContainerClient(new Uri(sasUrl));
        var blobClient = containerClient.GetBlobClient($"evento-{id}.txt");        var json = Encoding.UTF8.GetString(@event.Body.ToArray());
        var conteudo = $"Produto recebido em {DateTime.UtcNow}  + {json}";        blobClient.Upload(BinaryData.FromString(conteudo), overwrite: true);
    }
}