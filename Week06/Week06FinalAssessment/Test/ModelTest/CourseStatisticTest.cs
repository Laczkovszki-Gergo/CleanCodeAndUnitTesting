using Moq;
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
    public class CourseStatisticTest
    {
        Course Course;
        Mock<Lecturer> MockLecturer;

        [SetUp]
        public void Setup()
        {
            MockLecturer = new Mock<Lecturer>();
            Course = new Course(MockLecturer.Object, "Test course", DateTime.Now, 10, 1000);
        }

        [Test]
        [TestCase(1,10)]
        [TestCase(2, 20)]
        [TestCase(3, 30)]
        [TestCase(4,40)]

        public void CourseStatistic_Constructor_CreatesInstanceWithCorrectValues(int completedLecture,double progress)
        {
            // Arrange
            string expectedresult = Course.GetCourseName() + ";" + Course.GetLenghtInWeeks() + ";" + completedLecture + ";" + progress + ";" + Course.GetLastAccesed();
            DateTime expectedLastAccessed = DateTime.Now;

            // Act
            for (int i = 0; i < completedLecture; i++)
            {
                Course.CompleteLecture();
            }
            var courseStatistic = new CourseStatistic(Course);

            // Assert
            ClassicAssert.AreEqual(expectedresult, courseStatistic.GetStatisticOfCourse());
        }
    }
}
