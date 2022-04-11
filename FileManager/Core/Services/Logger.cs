using Serilog;

namespace FileManager.Core.Services
{
    public static class Logger
    {
        public static ILogger Log =>
            new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/file_manager_log.txt")
                .CreateLogger();
    }
}
