using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Employees
{
    public interface IReportGenerator
    {
        string GenerateEmployeeReports();
    }

    public class ReportGenerator : IReportGenerator
    {
        List<Employee> Employees;
        public ReportGenerator(List<Employee> employees)
        {
            Employees = employees;
        }
        public string GenerateEmployeeReports()
        {
            string data = string.Empty;
            foreach (var emp in Employees)
            {
                data += @"\n Employee name: " + emp.GetEmployeeName() + " - Employee Salary: " + emp.GetSalary().ToString();
            }
            return "Employee reports:" + data;
        }
    }
}
