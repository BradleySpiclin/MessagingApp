namespace MessagingApp.Infrastructure;

public class Logger : ILogger
{
    private static readonly string writePath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "messagingApp.log");

    public Logger()
    {
        var directoryPath = Path.GetDirectoryName(writePath);

        if (directoryPath is not null && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        Log("INFO", nameof(Logger), nameof(Logger), "Logger initialized");
    }

    public void Debug(string operationClass, string operationMethod, string debuggingInfo)
    {
        Log("DEBUG", operationClass, operationMethod, debuggingInfo);
    }

    public void Info(string operationClass, string operationMethod, string debuggingInfo)
    {
        Log("INFO", operationClass, operationMethod, debuggingInfo);
    }

    public void Exception(string operationClass, string operationMethod, Exception exception, string info = "")
    {
        var exceptionInfo = $"{info} - Exception: {exception.Message}, StackTrace: {exception.StackTrace}";

        Log("ERROR", operationClass, operationMethod, exceptionInfo);
    }

    private static void Log(string logLevel, string operationClass, string operationMethod, string message)
    {
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {operationClass}.{operationMethod}: {message}{Environment.NewLine}";

        File.AppendAllText(writePath, logMessage);
    }
}
