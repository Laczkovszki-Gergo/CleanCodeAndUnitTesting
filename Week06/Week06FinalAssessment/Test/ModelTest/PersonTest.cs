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
    public class PersonTest
    {
        const string fullName = "John Doe";
        static DateTime birthDate = new DateTime(1980, 1, 1);
        const string address = "123 Main St";
        const string emailAddress = "john@example.com";
        const string studentNo = "S10001";
        const string lecturerNo = "L10001";
        static DateTime dateOfRegistration = new DateTime(2020, 10, 12);

        Lecturer Lecturer;
        Student Student;

        [SetUp]
        public void SetUp()
        {
            Lecturer = new Lecturer(fullName, birthDate, address, emailAddress, lecturerNo);
            Student = new Student(fullName, birthDate, address, emailAddress,studentNo,dateOfRegistration);
        }

        [Test]
        public void Student_ShouldInheritFromPerson()
        {
            // Arrange

            // Assert
            ClassicAssert.IsInstanceOf<Person>(Student);
        }

        [Test]
        public void Lecturer_ShouldInheritFromPerson()
        {
            // Arrange

            // Assert
            ClassicAssert.IsInstanceOf<Person>(Lecturer);
        }

        [Test]
        public void Person_ShouldHaveBasicProperties()
        {
            // Arrange
            var person = new Student("John Doe", new DateTime(1990, 1, 1), "123 Main St", "john@example.com", "S12345", DateTime.Now);
            // Assert
            ClassicAssert.AreEqual("John Doe", person.GetFullName());
            ClassicAssert.AreEqual(new DateTime(1990, 1, 1), person.GetBirthDate());
            ClassicAssert.AreEqual("123 Main St", person.GetAddress());
            ClassicAssert.AreEqual("john@example.com", person.GetEmailAddress());
        }
    }
}
