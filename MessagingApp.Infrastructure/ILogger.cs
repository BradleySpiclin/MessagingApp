namespace MessagingApp.Infrastructure;

public interface ILogger
{
    void Debug(string operationClass, string operationMethod, string debuggingIngo);

    void Info(string operationClass, string operationMethod, string debuggingIngo);

    void Exception(string operationClass, string operationMethod, Exception exception, string info = "");
}