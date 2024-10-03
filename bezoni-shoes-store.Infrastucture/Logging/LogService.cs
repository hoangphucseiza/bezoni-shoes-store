using bezoni_shoes_store.Application.Common.Interfaces.Logging;
using Serilog;

namespace bezoni_shoes_store.Infrastucture.Logging
{
    public class LogService : ILogService
    {
        public void LogError(string message)
        {
           Log.Error(message);
        }

        public void LogInformation(string message)
        {
           Log.Information(message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }
    }
}
