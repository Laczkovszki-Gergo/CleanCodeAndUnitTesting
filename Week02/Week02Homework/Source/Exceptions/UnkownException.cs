using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02Homework.Source.Exceptions
{
    public class UnkownException : Exception
    {
        public UnkownException(string message) : base(message)
        {

        }
    }
}
