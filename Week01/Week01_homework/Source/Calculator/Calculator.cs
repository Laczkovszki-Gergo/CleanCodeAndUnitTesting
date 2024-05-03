using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
        internal static class Calculator
        {
            internal static Addition Addition = new Addition();
            internal static Subtraction Subtraction = new Subtraction();
            internal static Multiplication Multiplication = new Multiplication();
            internal static Division Division = new Division();
            internal static SquareRoot SquareRoot = new SquareRoot();
            internal static Power Power = new Power();
        }   
}
