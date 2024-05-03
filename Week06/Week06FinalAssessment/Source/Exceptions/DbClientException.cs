using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Exceptions
{
    public class DbClientException : Exception
    {
        public DbClientException(string message) : base(message)
        {
        }

        public DbClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
