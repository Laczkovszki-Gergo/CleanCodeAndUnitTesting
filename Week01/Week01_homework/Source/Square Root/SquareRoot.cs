using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
    internal class SquareRoot
    {
        internal double Squ(double a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Math.Sqrt(a);
        }
    }
}
