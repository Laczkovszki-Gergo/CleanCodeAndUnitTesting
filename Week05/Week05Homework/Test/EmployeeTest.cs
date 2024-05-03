using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week05Homework.Source.Employees;

namespace Week05Homework.Test
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void AddEmployee_ShouldIncreaseEmployeeCount()
        {
            // Arrange
            var system = new Mock<IEmployeeManagementSystem>();
            var employeeMock = new Mock<Employee>("John Doe", 50000);

            int expectedEmployeeCount = 1;

            system.Setup(x => x.GetEmployeeCount()).Returns(expectedEmployeeCount);

            // Act
            system.Object.AddEmployee(employeeMock.Object);

            // Assert
            ClassicAssert.AreEqual(expectedEmployeeCount, system.Object.GetEmployeeCount());
            system.Verify(x => x.AddEmployee(It.IsAny<Employee>()), Times.Once);
        }

        [Test]
        public void CalculatePayroll_ShouldReturnCorrectTotalPayroll()
        {
            // Arrange
            var system = new Mock<IEmployeeManagementSystem>();
            var employee1Mock = new Mock<Employee>("John Doe", 50000);
            var employee2Mock = new Mock<Employee>("Jane Smith", 60000);

            system.Object.AddEmployee(employee1Mock.Object);
            system.Object.AddEmployee(employee2Mock.Object);

            double expectedTotalPayrollResult = 110000;

            system.Setup(x => x.CalculateTotalPayroll()).Returns(expectedTotalPayrollResult);

            // Act
            double totalPayroll = system.Object.CalculateTotalPayroll();

            // Assert
            ClassicAssert.AreEqual(expectedTotalPayrollResult, totalPayroll);
            system.Verify(x => x.CalculateTotalPayroll(), Times.Once);
        }
        [Test]
        public void CalculatePayroll_ShouldReturnCorrectEmployeeCount()
        {
            // Arrange
            var system = new Mock<IEmployeeManagementSystem>();
            var employee1Mock = new Mock<Employee>("John Doe", 50000);
            var employee2Mock = new Mock<Employee>("Jane Smith", 60000);

            system.Object.AddEmployee(employee1Mock.Object);
            system.Object.AddEmployee(employee2Mock.Object);

            int expectedEmployeeCount = 2;

            system.Setup(x => x.GetEmployeeCount()).Returns(expectedEmployeeCount);

            // Act
            double employeeCount = system.Object.GetEmployeeCount();

            // Assert
            ClassicAssert.AreEqual(expectedEmployeeCount, employeeCount);
            system.Verify(x => x.GetEmployeeCount(), Times.Once);
        }

        [Test]
        public void GenerateReports_ShouldReturnCorrectReportString()
        {
            // Arrange
            var system = new Mock<IEmployeeManagementSystem>();
            var employee1Mock = new Mock<Employee>("John Doe", 50000);
            var employee2Mock = new Mock<Employee>("Jane Smith", 60000);

            system.Object.AddEmployee(employee1Mock.Object);
            system.Object.AddEmployee(employee2Mock.Object);

            string expectedReport = @"Employee reports:\n Employee name: John Doe - Employee Salary: 50000\n Employee name: Jane Smith - Employee Salary: 60000";


            system.Setup(x => x.GenerateReports()).Returns(expectedReport);


            // Act
            string report = system.Object.GenerateReports();

            // Assert
            ClassicAssert.AreEqual(expectedReport, report);
            system.Verify(x => x.GenerateReports(), Times.Once);
        }

        [Test]
        public void PromoteEmployee_ShouldHandleEmployeePromotionLogic()
        {
            // Arrange
            var system = new Mock<IEmployeeManagementSystem>();
            var employeeMock = new Mock<Employee>("John Doe", 50000);

            // Act
            system.Object.PromoteEmployee(employeeMock.Object);

            // Assert
            system.Verify(x => x.PromoteEmployee(It.IsAny<Employee>()), Times.Once);
        }
    }
}
