using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = DateTime.Now.Year - 2004;
            if (DateTime.Now.DayOfYear < new DateTime(2004, 05, 20).DayOfYear)
                a = a - 1;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
