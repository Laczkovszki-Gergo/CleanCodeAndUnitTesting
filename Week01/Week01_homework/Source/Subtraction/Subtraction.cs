using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
    internal class Subtraction
    {
        internal double Sub(double a, double b)
        {
            return Math.Round((a - b), 4);
            //Kell a Math.Round mert különben nem egyenlőek PL:
            //Assert.That(actual, Is.EqualTo(expected))
            //Expected: 1.2d
            //But was:  1.1999999999999997d
        }
    }
}
