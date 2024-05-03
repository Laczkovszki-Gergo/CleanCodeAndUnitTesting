using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Models;
using Moq;
using Week06FinalAssessment.Source.Exceptions;
using Week06FinalAssessment.Source.Abstraction.Clients;

namespace Week06FinalAssessment.Test.ClientTest
{
    [TestFixture]
    public class DbClientTest
    {
        private Mock<IDbClient> MockDbClient;
        Mock<Course> MockCourse1;
        Mock<Course> MockCourse2;
        Mock<Lecturer> MockLecturer;

        private DbClient DbClient;


        [SetUp]
        public void Setup()
        {
            MockDbClient = new Mock<IDbClient>();
            MockCourse1 = new Mock<Course>();
            MockCourse2 = new Mock<Course>();
            MockLecturer = new Mock<Lecturer>();

            DbClient = new DbClient();
        }

        [Test]
        public async Task SaveCourse_ValidCourse_CourseSavedSuccessfully()
        {
            // Arrange
            var course = new Course(MockLecturer.Object,"Test Course", DateTime.Now, 8, 1000);

            // Act
            await DbClient.SaveCourse(course);
            var result = await DbClient.GetCourseByName(course.GetCourseName());

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(course.GetCourseName(), result.GetCourseName());
            // Add more assertions as needed
        }

        [Test]
        public async Task GetCourseByName_CourseNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var courseName = "NonExistingCourse";

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => DbClient.GetCourseByName(courseName));
        }

        [Test]
        public async Task GetAllCourses_NoCourses_ReturnsEmptyList()
        {
            // Act
            var result = await DbClient.GetAllCourses();

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task GetAllCourses_MultipleCourses_ReturnsAllCourses()
        {
            // Arrange
            var expectedCourses = new List<Course> { new Course(MockLecturer.Object,"Course 1", DateTime.Now, 8, 1000), new Course(MockLecturer.Object, "Course 2", DateTime.Now, 6, 800) };
            foreach (var course in expectedCourses)
            {
                await DbClient.SaveCourse(course);
            }

            // Act
            var result = await DbClient.GetAllCourses();

            // Assert
            CollectionAssert.AreEquivalent(expectedCourses, result);
        }

        [Test]
        public void SaveCourse_NullCourse_ThrowsArgumentNullException()
        {
            // Arrange
            Course nullCourse = null;

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => DbClient.SaveCourse(nullCourse));
        }

        [Test]
        public void GetCourseByName_NullCourseName_ThrowsArgumentNullException()
        {
            // Arrange
            string nullCourseName = null;

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => DbClient.GetCourseByName(nullCourseName));
        }

        [Test]
        public void GetCourseByName_EmptyCourseName_ThrowsArgumentException()
        {
            // Arrange
            string emptyCourseName = string.Empty;

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => DbClient.GetCourseByName(emptyCourseName));
        }

        [Test]
        public async Task GetCourseByName_NonExistingCourse_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingCourseName = "NonExistingCourse";

            // Act & Assert
            ClassicAssert.ThrowsAsync<KeyNotFoundException>(() => DbClient.GetCourseByName(nonExistingCourseName));
        }

        [Test]
        public async Task GetCourseByName_ValidCourseName_ReturnsCourse()
        {
            // Arrange
            var courseName = "ExistingCourse";
            MockDbClient.Setup(x => x.GetCourseByName(courseName)).ReturnsAsync(MockCourse1.Object);

            // Act
            var result = await MockDbClient.Object.GetCourseByName(courseName);

            // Assert
            ClassicAssert.AreEqual(MockCourse1.Object, result);
        }

        [Test]
        public async Task GetCourseByName_EmptyCourseName_ThrowsArgumentNullException()
        {
            // Arrange
            string courseName = "";
            MockDbClient.Setup(x => x.GetCourseByName(courseName)).ThrowsAsync(new ArgumentNullException());

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await MockDbClient.Object.GetCourseByName(courseName));
        }

        [Test]
        public async Task GetCourseByName_NonExistingCourseName_ThrowsKeyNotFoundException()
        {
            // Arrange
            var courseName = "NonExistingCourse";
            MockDbClient.Setup(x => x.GetCourseByName(courseName)).ThrowsAsync(new KeyNotFoundException());

            // Act & Assert
            ClassicAssert.ThrowsAsync<KeyNotFoundException>(async () => await MockDbClient.Object.GetCourseByName(courseName));
        }

        [Test]
        public async Task GetCourseByName_DbClientException_ThrowsDbClientException()
        {
            // Arrange
            var courseName = "ExistingCourse";
            var expectedException = new DbClientException("Error occurred while getting the course by name.");
            MockDbClient.Setup(x => x.GetCourseByName(courseName)).ThrowsAsync(expectedException);

            // Act & Assert
            var result = ClassicAssert.ThrowsAsync<DbClientException>(async () => await MockDbClient.Object.GetCourseByName(courseName));
            ClassicAssert.AreEqual(expectedException, result);
        }
    }
}
