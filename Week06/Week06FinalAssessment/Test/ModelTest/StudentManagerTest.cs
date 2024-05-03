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
    public class StudentManagerTest
    {
        const string fullName = "John Doe";
        static DateTime birthDate = new DateTime(1980, 1, 1);
        const string address = "123 Main St";
        const string emailAddress = "john@example.com";
        const string studentNo = "S10001";
        const string lecturerNo = "L10001";
        static DateTime dateOfRegistration = new DateTime(2020, 10, 12);

        Student Student;
        Student Student2;
        StudentManager StudentManager;

        [SetUp]
        public void SetUp()
        {
            Student = new Student(fullName, birthDate, address, emailAddress, studentNo, dateOfRegistration);
            Student2 = new Student("John Smith", new DateTime(1992, 5, 5), "789 Oak St", "john@example.com", "S00002", DateTime.Now);

            StudentManager = new StudentManager();
        }

        [Test]
        public void AddStudent_StudentAddedSuccessfully()
        {
            // Arrange

            // Act
            StudentManager.AddStudent(Student);

            // Assert
            ClassicAssert.AreEqual(1, StudentManager.GetStudentsCount());
        }

        [Test]
        public void GetStudentsCount_NoStudents_ReturnsZero()
        {
            // Arrange

            // Act
            var result = StudentManager.GetStudentsCount();

            // Assert
            ClassicAssert.Zero(result);
        }

        [Test]
        public void GetStudentsCount_OneStudent_ReturnsOne()
        {
            // Arrange
            StudentManager.AddStudent(Student);

            // Act
            var result = StudentManager.GetStudentsCount();

            // Assert
            ClassicAssert.AreEqual(1, result);
        }

        [Test]
        public void GetStudents_ReturnsListOfStudents()
        {
            // Arrange
            StudentManager.AddStudent(Student);
            StudentManager.AddStudent(Student2);

            // Act
            var result = StudentManager.GetStudents();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.Contains(Student, result);
            ClassicAssert.Contains(Student2, result);
        }
    }
}
