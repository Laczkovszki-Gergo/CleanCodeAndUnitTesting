using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
    internal class Power
    {
        internal double Pow(double a, double b)
        {
                double result = Math.Round(Math.Pow(a, b), 4);
                if (double.IsNaN(result) || double.IsInfinity(result))
                {
                    throw new OverflowException();
                }
                return result;
        }
    }
}
