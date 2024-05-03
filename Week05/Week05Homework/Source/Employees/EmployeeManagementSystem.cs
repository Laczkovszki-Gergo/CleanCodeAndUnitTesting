using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Employees
{
    public interface IEmployeeManagementSystem
    {
        void AddEmployee(Employee employee);
        double CalculateTotalPayroll();
        string GenerateReports();
        int GetEmployeeCount();
        void PromoteEmployee(Employee employee);
    }

    public class EmployeeManagementSystem : IEmployeeManagementSystem
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeManagementSystem()
        {

        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public double CalculateTotalPayroll()
        {
            PayrollCalculator payrollCalculator = new PayrollCalculator(employees);

            return payrollCalculator.CalculateTotalPayroll();
        }

        public string GenerateReports()
        {
            ReportGenerator reportGenerator = new ReportGenerator(employees);

            return reportGenerator.GenerateEmployeeReports();
        }

        public int GetEmployeeCount()
        {
            return employees.Count;
        }

        public void PromoteEmployee(Employee employee)
        {
            // Kód az alkalmazott előléptetési logikájának kezelésére
        }
    }
}
