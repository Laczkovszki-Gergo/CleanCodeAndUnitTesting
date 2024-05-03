using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Employees
{
    public interface IEmployee
    {
        double GetSalary();
        string GetEmployeeName();
    }

    public class Employee : IEmployee
    {
        private string name;
        private double salary;

        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public double GetSalary()
        {
            return this.salary;
        }
        public string GetEmployeeName()
        {
            return this.name;
        }
    }
}
