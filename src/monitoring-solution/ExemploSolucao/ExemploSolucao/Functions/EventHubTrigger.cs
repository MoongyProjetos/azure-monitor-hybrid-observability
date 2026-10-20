using Azure.Messaging.EventHubs;
using ExemploSolucao.DTO;
using ExemploSolucao.Mapper;
using ExemploSolucao.Models;
using ExemploSolucao.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace ExemploSolucao.Functions;

public class EventHubTrigger
{
    private readonly ILogger<EventHubTrigger> _logger;
    private readonly IDbContextFactory<SqldbMonitorJnPrdContext> _dbContextFactory;

    public EventHubTrigger(ILogger<EventHubTrigger> logger, IDbContextFactory<SqldbMonitorJnPrdContext> dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    [Function(nameof(EventHubTrigger))]
    public async Task Run([EventHubTrigger("source", Connection = "EventHubConnection")] EventData[] events)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync();

        foreach (EventData @event in events)
        {
            try
            {
                var content = @event.EventBody.ToString();

                var dto = JsonSerializer.Deserialize<YellowTaxiTripDto>(@event.EventBody.ToString());

                if (dto is null)
                {
                    _logger.LogWarning("Evento sem conteúdo válido.");
                    continue;
                }

                var trip = YellowTaxiTripMapper.ToEntity(dto);

                var dependencyService = new TripDependencyService(db);

                await dependencyService.EnsureDependenciesAsync(trip);

                // Agora as dependências existem.
                db.Trips.Add(trip);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar o evento do Event Hub.");
            }
        }
    }
}