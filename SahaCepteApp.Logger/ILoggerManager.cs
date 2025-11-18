namespace SahaCepteApp.Logger;

public interface ILoggerManager
{
    void LogInfo(string message);
    void LogInfo(string userId, string message);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string userId,string message);
    void LogError(string message);
}