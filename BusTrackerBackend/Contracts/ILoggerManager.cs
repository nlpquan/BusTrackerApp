using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);

        void LogDebug(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogInfo(string message, params object[] args);
        void LogWarn(string message, params object[] args);
    }
}
