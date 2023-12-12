using Redacted.Redaction;

namespace Redacted;

public partial class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                Log(_logger, DateTimeOffset.Now, new());
            }

            await Task.Delay(1000, stoppingToken);
        }
    }

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Worker running at: {Now} ")]
    private static partial void Log(ILogger logger, DateTimeOffset now, [LogProperties] Secrets secrets);
}

public record Secrets(
    [Personal] string Name = "Khalid",
    [Sensitive] string Password = "123",
    [Default] string FavoriteFood = "Pizza");