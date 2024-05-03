using Moq;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Repository;

namespace Week06FinalAssessment.Test.RepositoryTest
{
    [TestFixture]
    public class CourseRepositoryTest
    {
        private Mock<IDbClient> MockDbClient;
        private Mock<Lecturer> MockLecturer;
        private CourseRepository CourseRepository;
        private Course Course;
        private Mock<Student> MockStudent;

        const string CourseName = "Test Course";

        [SetUp]
        public void Setup()
        {
            MockDbClient = new Mock<IDbClient>();
            MockLecturer = new Mock<Lecturer>();
            MockStudent = new Mock<Student>();

            CourseRepository = new CourseRepository(MockDbClient.Object);
            Course = new Course(MockLecturer.Object,CourseName, It.IsAny<DateTime>(), It.IsAny<Int32>(), It.IsAny<Decimal>());
        }

        [Test]
        public async Task AddCourse_ValidCourse_CourseAddedSuccessfully()
        {
            // Arrange

            // Act
            await CourseRepository.AddCourse(It.IsAny<Course>());

            // Assert
            MockDbClient.Verify(x => x.SaveCourse(It.IsAny<Course>()), Times.Once);
        }

        [Test]
        public async Task AddStudentToCourse_ValidStudentAndCourse_StudentAddedToCourse()
        {
            // Arrange
            MockDbClient.Setup(x => x.GetCourseByName(CourseName)).ReturnsAsync(Course);

            // Act
            await CourseRepository.AddStudentToCourse(MockStudent.Object, CourseName);

            // Assert
            ClassicAssert.Contains(MockStudent.Object, Course.GetStudents());
        }

        [Test]
        public async Task GetCourseByName_ExistingCourse_ReturnsCourse()
        {
            // Arrange
            var expectedCourse = new Course(MockLecturer.Object, CourseName, DateTime.Now, 8, 1000);
            MockDbClient.Setup(x => x.GetCourseByName(CourseName)).ReturnsAsync(expectedCourse);

            // Act
            var result = await CourseRepository.GetCourseByName(CourseName);

            // Assert
            ClassicAssert.AreEqual(expectedCourse, result);
        }

        [Test]
        public void GetCourseByName_NonExistingCourse_ThrowsException()
        {
            // Arrange
            MockDbClient.Setup(x => x.GetCourseByName(It.IsAny<string>())).ThrowsAsync(new InvalidOperationException());

            // Act & Assert
            ClassicAssert.ThrowsAsync<InvalidOperationException>(() => CourseRepository.GetCourseByName(It.IsAny<string>()));
        }

        [Test]
        [TestCase("Course 1", 8, 1000)]
        [TestCase("Course 2", 6, 800)]
        [TestCase("Course 3", 10, 1200)]
        public async Task GetCourses_ReturnsListOfCourses(string courseName, int lengthInWeeks, decimal costInHuf)
        {
            // Arrange
            var courses = new List<Course> { Course };

            MockDbClient.Setup(x => x.GetAllCourses()).ReturnsAsync(courses);

            // Act
            var result = await CourseRepository.GetCourses();

            // Assert
            CollectionAssert.AreEqual(courses, result);
        }

        [Test]
        public void GetCourseStatistics_ExistingCourse_ReturnsCourseStatistic()
        {
            // Arrange
            var expectedStatistic = new CourseStatistic(Course);
            MockDbClient.Setup(x => x.GetCourseByName(CourseName)).ReturnsAsync(Course);

            // Act
            var result = CourseRepository.GetCourseStatistics(Course.GetCourseName());

            // Assert
            ClassicAssert.AreEqual(expectedStatistic.GetStatisticOfCourse(), result.Result.GetStatisticOfCourse());
        }

        [Test]
        public void GetCourseStatistics_NonExistingCourse_ThrowsException()
        {
            // Arrange
            MockDbClient.Setup(x => x.GetCourseByName(It.IsAny<string>())).ReturnsAsync((Course)null);

            // Act & Assert
            ClassicAssert.ThrowsAsync<InvalidOperationException>(() => CourseRepository.GetCourseStatistics(It.IsAny<string>()));
        }
    }
}
