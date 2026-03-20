using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;var builder = FunctionsApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdventureWorksDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));builder.ConfigureFunctionsWebApplication();builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();builder.Build().Run();
