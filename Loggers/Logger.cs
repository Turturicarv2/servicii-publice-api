using Serilog;

namespace ServiciiPubliceBackend.Loggers
{
    public static class Logger
    {
        public static void LogInformation(string message)
        {
            Log.Information(message);
        }

        public static void LogError(string message) 
        { 
            Log.Error(message); 
        }
    }
}
