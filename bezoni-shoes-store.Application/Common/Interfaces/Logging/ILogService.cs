using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Logging
{
    public interface ILogService
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
