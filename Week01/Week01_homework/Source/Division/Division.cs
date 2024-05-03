using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
    internal class Division
    {
        internal double Div(double a, double b)
        {
            if(b == 0)
            {
                throw new DivideByZeroException();
            }
            return Math.Round((a / b), 4);
        }
    }
}
