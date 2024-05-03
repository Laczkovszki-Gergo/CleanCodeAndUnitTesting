using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Test.ModelTest
{
    [TestFixture]
    public class CourseTest
    {
        const string courseName = "Test Course";

        private Lecturer lecturer;
        private Course course;
        private Student student;

        [SetUp]
        public void Setup()
        {
            lecturer = new Lecturer("John Smith", new DateTime(1987, 10, 10), "Test address", "Test@adress.com", "L10000");
            course = new Course(lecturer, courseName, DateTime.Now, 6, 1000);
            student = new Student("John Doe", new DateTime(1990, 1, 1), "123 Main St", "john@example.com", "S00001", DateTime.Now);
        }
        public void AddStudent_StudentAddedSuccessfully()
        {
            // Arrange

            // Act
            course.AddStudent(student);

            // Assert
            ClassicAssert.IsTrue(course.GetStudents().Contains(student));
        }

        [Test]
        public void GetCourseName_ValidCourse_ReturnsCourseName()
        {
            // Arrange

            // Act
            var result = course.GetCourseName();

            // Assert
            ClassicAssert.AreEqual(courseName, result);
        }

        [Test]
        public void GetStudentsCountOfCourse_NoStudents_ReturnsZero()
        {
            // Arrange

            // Act
            var result = course.GetStudentsCountOfCourse();

            // Assert
            ClassicAssert.Zero(result);
        }

        [Test]
        public void GetStudentsCountOfCourse_OneStudent_ReturnsOne()
        {
            // Arrange
            course.AddStudent(new Student("John Doe", new DateTime(1990, 1, 1), "123 Main St", "john@example.com", "S00001", DateTime.Now));

            // Act
            var result = course.GetStudentsCountOfCourse();

            // Assert
            ClassicAssert.AreEqual(1, result);
        }

        [TestCase(0, 0)]
        [TestCase(6, 0)]
        [TestCase(6, 3)]
        [TestCase(6, 6)]
        public void GetProgress_VariousLectureCompletion_ReturnsCorrectPercentage(int totalLectures, int completedLectures)
        {
            // Arrange
            var course = new Course(lecturer, courseName, DateTime.Now, totalLectures, 1000);
            for (int i = 0; i < completedLectures; i++)
            {
                course.CompleteLecture();
            }

            // Expected progress calculation
            double expectedProgress = (double)completedLectures / (double)totalLectures * 100;

            // Act
            var result = course.GetProgress();

            // Assert
            ClassicAssert.AreEqual(expectedProgress, result);
        }
        [Test]
        public void GetCompletedLecturesCount_NoCompletedLectures_ReturnsZero()
        {
            // Arrange

            // Act
            var result = course.GetCompledtedLecturesCount();

            // Assert
            ClassicAssert.Zero(result);
        }
        [Test]
        public void GetCompletedLecturesCount_SomeCompletedLectures_ReturnsCorrectCount()
        {
            // Arrange
            int expectedCompletedLectures = 3;
            for (int i = 0; i < expectedCompletedLectures; i++)
            {
                course.CompleteLecture();
            }

            // Act
            var result = course.GetCompledtedLecturesCount();

            // Assert
            ClassicAssert.AreEqual(expectedCompletedLectures, result);
        }
    }
}
