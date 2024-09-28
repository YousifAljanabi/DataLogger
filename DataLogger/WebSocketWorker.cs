using DataLoggerDatabase.Helpers;
using DataLoggerDatabase.Models;
using DataLoggerDatabase;

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace DataLogger;

public class WebSocketWorker : BackgroundService
{
    private readonly ILogger<WebSocketWorker> _logger;
    private readonly IHubContext<DataHub, IDataHub> _dataHub;
    private readonly IServiceProvider _serviceProvider;

    public WebSocketWorker(ILogger<WebSocketWorker> logger, IHubContext<DataHub, IDataHub> dataHub, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _dataHub = dataHub;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var stations = await context.Stations.ToListAsync(stoppingToken);
            
            foreach (var station in stations)
            {
                var latestPipesData = await context.PipesData
                    .Where(x => x.StationId == station.Id)
                    .OrderByDescending(x => x.TimeStamp)
                    .FirstOrDefaultAsync(stoppingToken);
                
                // var latestPipesDataSerialized = StringUtils.SerializeObject(latestPipesData);
                // var stationSerialized = StringUtils.SerializeObject(station);
                // await _dataHub.Clients.All.ReceiveStationData(stationSerialized, latestPipesDataSerialized);
                if (latestPipesData != null)
                {
                    await _dataHub.Clients.All.ReceiveStationData(station, latestPipesData);
                }

            }


            
            await Task.Delay(60000, stoppingToken);

        }
    }
}


public class DataHub : Hub<IDataHub>
{
    private readonly ILogger<DataHub> _logger;

    public DataHub(ILogger<DataHub> logger)
    {
        _logger = logger;
    }
    public async Task SendMessage(string message)
    {
        _logger.LogInformation("Sending message: {Message}", message);
        await Clients.All.SendMessage(message);
    }
    public async Task ReceiveStationData(Station station, PipesData latestPipesData)
    {
        _logger.LogInformation("Sending data for station: {StationId}", station);
        await Clients.All.ReceiveStationData(station, latestPipesData);
    }
    
}
public interface IDataHub
{
    Task SendMessage(string message);
    Task ReceiveStationData(Station station, PipesData latestPipesData);

}