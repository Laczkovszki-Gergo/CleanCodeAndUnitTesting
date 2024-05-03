using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03Homework.Source
{
    public class Logger
    {
        private readonly IConsole _console;

        public Logger(IConsole console)
        {
            _console = console;
        }

        public virtual void Log(string message)
        {
            _console.Log(message);
        }
        public virtual void LogError(string errorMessage, Exception exception)
        {
            _console.LogError(errorMessage,exception);
        }
    }

    public interface IConsole
    {
        void Log(string message);
        void LogError(string message, Exception exception);
    }
}
