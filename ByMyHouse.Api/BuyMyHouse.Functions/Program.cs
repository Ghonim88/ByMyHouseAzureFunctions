using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BuyMyHouse.Api.DAL;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults() // Required for isolated worker
    .ConfigureServices(services =>
    {
        // Register your DAL here
        services.AddSingleton<IMortgageApplicationDAL, MortgageApplicationDAL>();
        // Add other services if needed
    })
    .Build();

host.Run();
