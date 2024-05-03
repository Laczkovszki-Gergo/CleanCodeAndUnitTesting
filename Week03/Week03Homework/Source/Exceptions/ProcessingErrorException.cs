using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03Homework.Source.Exceptions
{
    internal class ProcessingErrorException : Exception
    {
        private readonly Exception Exception;

        public ProcessingErrorException(string message, Exception exception) : base(message)
        {
            this.Exception = exception;
        }
    }
}
