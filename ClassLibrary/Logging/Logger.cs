using System.Text;
using Microsoft.Extensions.Logging;

public class FileLogger : ILogger
{
    private readonly string filePath;

    public FileLogger(string path)
    {
        filePath = path;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        string logRecord = $"{DateTime.UtcNow:O} [{logLevel}] {formatter(state, exception)}";
        File.AppendAllText(filePath, logRecord + Environment.NewLine);
    }
}

public class FileLoggerProvider : ILoggerProvider
{
    private readonly string path;

    public FileLoggerProvider(string path)
    {
        this.path = path;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(path);
    }

    public void Dispose()
    {
    }
}