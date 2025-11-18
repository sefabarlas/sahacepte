using Microsoft.Extensions.Logging;

namespace SahaCepteApp.Logger;

public class LoggerManager : ILoggerManager
{
    private static ILogger _logger = null!;

    public LoggerManager(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
    }
    public void LogDebug(string message)
    {
        _logger.LogDebug(message);
    }

    public void LogError(string message)
    {
        _logger.LogError(message);
    }

    public void LogError(string userId, string message)
    {
        _logger.LogError($"User : {userId} ActionLog : {message}");
    }

    public void LogInfo(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogInfo(string userId, string message)
    {
        _logger.LogInformation($"User : {userId} ActionLog : {message}");
    }
    
    public void LogWarn(string message)
    {
        _logger.LogWarning(message);
    }
}