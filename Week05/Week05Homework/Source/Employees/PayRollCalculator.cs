using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Employees
{
    public interface IPayrollCalculator
    {
        double CalculateTotalPayroll();
    }

    public class PayrollCalculator : IPayrollCalculator
    {
        List<Employee> Employees;
        public PayrollCalculator(List<Employee> employees)
        {
            Employees = employees;
        }
        public double CalculateTotalPayroll()
        {
            double totalPayroll = 0;
            foreach (var employee in Employees)
            {
                totalPayroll += employee.GetSalary();
            }
            return totalPayroll;
        }
    }
}
