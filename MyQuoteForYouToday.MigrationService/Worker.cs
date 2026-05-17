namespace MyQuoteForYouToday.MigrationService;

/// <summary>
/// Runs background migration-related tasks for the service.
/// </summary>
/// <param name="logger">Logger instance for worker diagnostics.</param>
public class Worker(ILogger<Worker> logger) : BackgroundService
{
    /// <summary>
    /// Executes the background loop until cancellation is requested.
    /// </summary>
    /// <param name="stoppingToken">Cancellation token for graceful shutdown.</param>
    /// <returns>A task that represents the background execution operation.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}