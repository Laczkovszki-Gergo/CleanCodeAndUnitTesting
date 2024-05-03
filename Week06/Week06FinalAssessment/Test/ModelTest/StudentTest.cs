using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Test.ModelTest
{
    [TestFixture]
    public class StudentTest
    {
        const string fullName = "John Doe";
        static DateTime birthDate = new DateTime(1980, 1, 1);
        const string address = "123 Main St";
        const string emailAddress = "john@example.com";
        const string studentNo = "S10001";
        static DateTime dateOfRegistration = new DateTime(2020, 10, 12);

        Student Student;

        [SetUp]
        public void SetUp()
        {
            Student = new Student(fullName, birthDate, address, emailAddress, studentNo, dateOfRegistration);
        }

        [Test]
        public void Constructor_ValidArguments_PropertiesSetCorrectly()
        {
            // Arrange

            // Act

            // Assert
            ClassicAssert.AreEqual(fullName, Student.GetFullName());
            ClassicAssert.AreEqual(birthDate, Student.GetBirthDate());
            ClassicAssert.AreEqual(address, Student.GetAddress());
            ClassicAssert.AreEqual(emailAddress, Student.GetEmailAddress());
            ClassicAssert.AreEqual(studentNo, Student.GetStudentNo());
            ClassicAssert.AreEqual(dateOfRegistration, Student.GetRegistrationDate());
        }

        [Test]
        public void GetStudentNo_InitializedWithConstructor_ReturnsCorrectValue()
        {
            // Arrange

            // Act
            var result = Student.GetStudentNo();

            // Assert
            ClassicAssert.AreEqual(studentNo, result);
        }

        [Test]
        public void GetStudentNo_DefaultConstructor_ReturnsNull()
        {
            // Arrange
            var student = new Student();

            // Act
            var result = student.GetStudentNo();

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void GetRegistrationDate_InitializedWithConstructor_ReturnsCorrectValue()
        {
            // Arrange

            // Act
            var result = Student.GetRegistrationDate();

            // Assert
            ClassicAssert.AreEqual(dateOfRegistration, result);
        }

        [Test]
        public void GetRegistrationDate_DefaultConstructor_ReturnsDefaultDateTime()
        {
            // Arrange
            var student = new Student();

            // Act
            var result = student.GetRegistrationDate();

            // Assert
            ClassicAssert.AreEqual(default(DateTime), result);
        }
    }
}
