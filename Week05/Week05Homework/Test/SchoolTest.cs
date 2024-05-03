using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week05Homework.Source.Schools;

namespace Week05Homework.Test
{
    [TestFixture]
    public class SchoolTests
    {
        [Test]
        public void GetStudentCount_ShouldReturnZero_WhenNoClassesAdded()
        {
            // Arrange
            var school = new School();

            // Act
            int studentCount = school.GetStudentCount();

            // Assert
            ClassicAssert.AreEqual(0, studentCount);
        }

        [Test]
        public void GetStudentCount_ShouldReturnCorrectCount_WhenClassesAdded()
        {
            // Arrange
            var school = new School();
            var schoolClass1 = new SchoolClass();
            schoolClass1.AddStudent(new Student("John Doe"));
            schoolClass1.AddStudent(new Student("Jane Smith"));
            school.AddClass(schoolClass1);

            var schoolClass2 = new SchoolClass();
            schoolClass2.AddStudent(new Student("Alice Johnson"));
            school.AddClass(schoolClass2);

            // Act
            int studentCount = school.GetStudentCount();

            // Assert
            ClassicAssert.AreEqual(3, studentCount);
        }
    }

    [TestFixture]
    public class SchoolClassTests
    {
        [Test]
        public void GetStudentCount_ShouldReturnZero_WhenNoStudentsAdded()
        {
            // Arrange
            var schoolClass = new SchoolClass();

            // Act
            int studentCount = schoolClass.GetStudentCount();

            // Assert
            ClassicAssert.AreEqual(0, studentCount);
        }

        [Test]
        public void GetStudentCount_ShouldReturnCorrectCount_WhenStudentsAdded()
        {
            // Arrange
            var schoolClass = new SchoolClass();
            schoolClass.AddStudent(new Student("John Doe"));
            schoolClass.AddStudent(new Student("Jane Smith"));
            schoolClass.AddStudent(new Student("Alice Johnson"));

            // Act
            int studentCount = schoolClass.GetStudentCount();

            // Assert
            ClassicAssert.AreEqual(3, studentCount);
        }
    }
}
