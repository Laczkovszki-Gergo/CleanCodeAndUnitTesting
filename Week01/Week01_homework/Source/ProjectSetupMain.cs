using NUnit.Framework;
using NUnit;
using System;
using NUnit.Framework.Legacy;

namespace ProjectSetup.Source
{
    class ProjectSetupMain
    {
        //Test data
        const int a = 10;
        const int b = 15;
        const int c = 0;
        const double d = 5.8;
        const double e = 4.4;
        const int f = 100000;
        const int g = 200000;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CWAddition();
            CWSubtraction();
            CWMultiplication();
            CWDivision();
            CWSquareRoot();
            CWPower();

            Console.ReadKey();
        }

        static void CWAddition()
        {
            //Addition
            Console.WriteLine("Addition (+)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => " + a.ToString() + " + " + b.ToString() + " = " + Calculator.Addition.Add(a, b));
            Console.WriteLine("Test with negative integers: => (" + (-a).ToString() + ") + (" + (-b).ToString() + ") = (" + Calculator.Addition.Add(-a, -b) + ")");
            Console.WriteLine("Test with zero: => " + a.ToString() + " + " + c.ToString() + " = " + Calculator.Addition.Add(a, c));
            Console.WriteLine("Test with floating-point numbers: => " + d.ToString() + " + " + e.ToString() + " = " + Calculator.Addition.Add(d, e));
            Console.WriteLine("Test the commutative property: a + b == b + a: => " + a.ToString() + " + " + b.ToString() + " == " + b.ToString() + " + " + a.ToString() + " = " + (Calculator.Addition.Add(a, b) == Calculator.Addition.Add(b, a)));
        }

        static void CWSubtraction()
        {
            //Subtraction
            Console.WriteLine();
            Console.WriteLine("Subtraction (-)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => " + a.ToString() + " - " + b.ToString() + " = (" + Calculator.Subtraction.Sub(a, b) + ")");
            Console.WriteLine("Test with negative integers: => (" + (-a).ToString() + ") - (" + (-b).ToString() + ") = " + Calculator.Subtraction.Sub(-a, -b));
            Console.WriteLine("Test with zero: => " + a.ToString() + " - " + c.ToString() + " = " + Calculator.Subtraction.Sub(a, c));
            Console.WriteLine("Test with floating-point numbers: => " + d.ToString() + " - " + e.ToString() + " = " + Calculator.Subtraction.Sub(d, e));
            Console.WriteLine("Test scenarios where (a - b) is less than (b - a): => ((" + a.ToString() + " - " + b.ToString() + ") < (" + b.ToString() + " - " + a.ToString() + ")) = " + (Calculator.Subtraction.Sub(a, b) < Calculator.Subtraction.Sub(b, a)));
            Console.WriteLine("Test scenarios where (b - a) is greater than (a - b): => ((" + b.ToString() + " - " + a.ToString() + ") > (" + a.ToString() + " - " + b.ToString() + ")) = " + (Calculator.Subtraction.Sub(b, a) > Calculator.Subtraction.Sub(a, b)));
        }

        static void CWMultiplication()
        {
            //Multiplication
            Console.WriteLine();
            Console.WriteLine("Multiplication (*)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => " + a.ToString() + " * " + b.ToString() + " = (" + Calculator.Multiplication.Mul(a, b) + ")");
            Console.WriteLine("Test with negative integers: => (" + (-a).ToString() + ") * (" + (-b).ToString() + ") = " + Calculator.Multiplication.Mul(-a, -b));
            Console.WriteLine("Test with zero: => " + a.ToString() + " * " + c.ToString() + " = " + Calculator.Multiplication.Mul(a, c));
            Console.WriteLine("Test with floating-point numbers: => " + d.ToString() + " * " + e.ToString() + " = " + Calculator.Multiplication.Mul(d, e));
            Console.WriteLine("Test the commutative property: a * b == b * a: => " + a.ToString() + " * " + b.ToString() + " == " + b.ToString() + " * " + a.ToString() + " = " + (Calculator.Multiplication.Mul(a, b) == Calculator.Multiplication.Mul(b, a)));
        }

        static void CWDivision()
        {
            //Division
            Console.WriteLine();
            Console.WriteLine("Division (/)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => " + a.ToString() + " / " + b.ToString() + " = (" + Calculator.Division.Div(a, b) + ")");
            Console.WriteLine("Test with negative integers: => (" + (-a).ToString() + ") / (" + (-b).ToString() + ") = " + Calculator.Division.Div(-a, -b));
            Console.WriteLine("Test with zero as devided: => " + c.ToString() + " / " + a.ToString() + " = " + Calculator.Division.Div(c, a));
            try
            {
                Console.WriteLine("Test with zero as devisor: => " + a.ToString() + " / " + c.ToString() + " = " + Calculator.Division.Div(a, c));
            }
            catch (Exception e)
            {
                Console.WriteLine("Test with zero as devisor: => " + a.ToString() + " / " + c.ToString() + " = " + e.Message);
            }
            Console.WriteLine("Test with floating-point numbers: => " + d.ToString() + " / " + e.ToString() + " = " + Calculator.Division.Div(d, e));
            try
            {
                Console.WriteLine("Test scenarios where division by zero should throw an Error: => " + a.ToString() + " / " + c.ToString() + " = " + Calculator.Division.Div(a, c));
            }
            catch (Exception e)
            {
                Console.WriteLine("Test scenarios where division by zero should throw an Error: => " + a.ToString() + " / " + c.ToString() + " = " + e.Message);
            }
        }

        static void CWSquareRoot()
        {
            //Square Root
            Console.WriteLine();
            Console.WriteLine("Square Root (√)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => √" + a.ToString() + " = " + Calculator.SquareRoot.Squ(a));
            Console.WriteLine("Test with zero: => √" + c.ToString() + " = " + Calculator.SquareRoot.Squ(c));
            try
            {
                Console.WriteLine("Test scenarios where calculating the square root of a negative number should throw an Error: => √(" + (-a).ToString() + ") = " + Calculator.SquareRoot.Squ(-a));
            }
            catch (Exception e)
            {
                Console.WriteLine("Test scenarios where calculating the square root of a negative number should throw an Error: => √(" + (-a).ToString() + ") = " + e.Message);
            }
        }

        static void CWPower()
        {
            //Square Root
            Console.WriteLine();
            Console.WriteLine("Power (^)");
            Console.WriteLine();
            Console.WriteLine("Test with positive integers: => " + a.ToString() + " ^ " + b.ToString() + " = " + Calculator.Power.Pow(a, b));
            Console.WriteLine("Test with negative integers: => (" + (-a).ToString() + ") ^ (" + (-b).ToString() + ") = (" + Calculator.Power.Pow(-a, -b) + ")");
            Console.WriteLine("Test with zero as base: => " + a.ToString() + " ^ " + b.ToString() + " = " + Calculator.Power.Pow(a, b));
            Console.WriteLine("Test with zero as exponent: => " + b.ToString() + " ^ " + a.ToString() + " = " + Calculator.Power.Pow(b, a));
            Console.WriteLine("Test with floating-point numbers: => " + a.ToString() + " ^ " + b.ToString() + " = " + Calculator.Power.Pow(b, a));
            try
            {
                Console.WriteLine("Test edge case scenarios with large numbers: => " + f.ToString() + " ^ " + g.ToString() + " = " + Calculator.Power.Pow(f, g));
            }
            catch (Exception e)
            {
                Console.WriteLine("Test edge case scenarios with large numbers: => " + f.ToString() + " ^ " + g.ToString() + " = " + e.Message);
            }
        }
    }
}
