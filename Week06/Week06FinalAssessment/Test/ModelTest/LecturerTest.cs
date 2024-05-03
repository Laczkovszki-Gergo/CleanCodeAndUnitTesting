using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Test.ModelTest
{
    [TestFixture]
    public class LecturerTest
    {
        const string fullName = "John Doe";
        static DateTime birthDate = new DateTime(1980, 1, 1);
        const string address = "123 Main St";
        const string emailAddress = "john@example.com";
        const string lecturerNo = "L10001";

        Lecturer Lecturer;

        [SetUp]
        public void SetUp()
        {
            Lecturer = new Lecturer(fullName, birthDate, address, emailAddress, lecturerNo);
        }
        [Test]
        public void Constructor_ValidArguments_PropertiesSetCorrectly()
        {
            // Arrange


            // Act

            // Assert
            ClassicAssert.AreEqual(fullName, Lecturer.GetFullName());
            ClassicAssert.AreEqual(birthDate, Lecturer.GetBirthDate());
            ClassicAssert.AreEqual(address, Lecturer.GetAddress());
            ClassicAssert.AreEqual(emailAddress, Lecturer.GetEmailAddress());
            ClassicAssert.AreEqual(lecturerNo, Lecturer.GetLecturerNo());
        }

        [Test]
        public void GetLecturerNo_InitializedWithConstructor_ReturnsCorrectValue()
        {
            // Arrange

            // Act
            var result = Lecturer.GetLecturerNo();

            // Assert
            ClassicAssert.AreEqual(lecturerNo, result);
        }

        [Test]
        public void GetLecturerNo_DefaultConstructor_ReturnsNull()
        {
            // Arrange
            var lecturer = new Lecturer();

            // Act
            var result = lecturer.GetLecturerNo();

            // Assert
            ClassicAssert.IsNull(result);
        }
    }
}
