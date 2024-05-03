using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Repository;
using Week06FinalAssessment.Source.Abstraction.Services;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Test.ServicesTest
{
    [TestFixture]
    public class CourseServiceTest
    {
        //Services

        private Mock<IPaymentService> MockPaymentService;
        private Mock<INotificationService> MockNotificationService;

        private CourseService TestCourseService;

        //Repository

        private Mock<ICourseRepository> MockCourseRepository;

        //Lecturer

        Mock<Lecturer> MockLecturer;

        //Student

        Mock<Student> MockStudent;

        Student TestStudent;

        DateTime TestStudentBirthDay = new DateTime(1996, 07, 10);
        DateTime TestStudentRegistrationDate = DateTime.Now;

        //Course

        Mock<Course> MockCourse;

        Course TestCourse;

        const string TestCourseName = "Test course";
        const decimal TestCourseCostInHuf = 600000;
        const int TestCourseLenghtInWeeks = 6;

        //CourseStatistic

        Mock<CourseStatistic> MockCourseStatistic;

        const string TestCourseStaticticCourseName = "Test course";

        [SetUp]
        public void Setup()
        {
            MockCourseRepository = new Mock<ICourseRepository>();
            MockPaymentService = new Mock<IPaymentService>();
            MockNotificationService = new Mock<INotificationService>();

            MockStudent = new Mock<Student>();
            MockLecturer = new Mock<Lecturer>();
            MockCourse = new Mock<Course>();
            MockCourseStatistic = new Mock<CourseStatistic>();

            TestCourseService = new CourseService(MockCourseRepository.Object, MockPaymentService.Object, MockNotificationService.Object);
            TestStudent = new Student(It.IsAny<string>(), TestStudentBirthDay, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), TestStudentRegistrationDate);
            TestCourse = new Course(MockLecturer.Object, TestCourseName, It.IsAny<DateTime>(), TestCourseLenghtInWeeks, TestCourseCostInHuf);
        }

        [Test]
        public async Task AddCourse_ShouldCallRepositoryAddCourse()
        {
            // Arrange

            // Act
            await TestCourseService.AddCourse(TestCourse);

            // Assert
            MockCourseRepository.Verify(repo => repo.AddCourse(TestCourse), Times.Once);
        }


        [Test]
        public async Task GetCourseByName_ShouldReturnCourse()
        {
            // Arrange
            MockCourseRepository.Setup(repo => repo.GetCourseByName(TestCourseName))
                .ReturnsAsync(TestCourse);

            // Act
            var result = await TestCourseService.GetCourseByName(TestCourseName);

            // Assert
            ClassicAssert.AreEqual(TestCourse, result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetCourses_ShouldReturnAllCourses(int numberOfCourses)
        {
            // Arrange
            var courses = new List<Course>();
            for (int i = 0; i < numberOfCourses; i++)
            {
                courses.Add(Mock.Of<Course>());
            }

            MockCourseRepository.Setup(repo => repo.GetCourses()).ReturnsAsync(courses);

            // Act
            var result = await TestCourseService.GetCourses();

            // Assert
            CollectionAssert.AreEqual(courses, result);
        }

        [Test]
        public async Task AddStudentToCourse_ValidCourse_StudentAdded()
        {
            // Arrange
            MockCourseRepository.Setup(repo => repo.GetCourseByName(TestCourse.GetCourseName()))
                .ReturnsAsync(TestCourse);
            MockPaymentService.Setup(service => service.GetIsOrderPayed(TestStudent, TestCourse))
                .ReturnsAsync(true);

            // Act
            await TestCourseService.AddStudentToCourse(TestStudent, TestCourse.GetCourseName());

            // Assert
            ClassicAssert.IsTrue(TestCourse.GetStudents().Contains(TestStudent));
            MockNotificationService.Verify(service => service.SendNotifications(
                $"{TestStudent.GetFullName()} student was added to course."), Times.Once);
        }

        [Test]
        public async Task AddStudentToCourse_WhenCourseNotFound_ShouldThrowException()
        {
            // Arrange

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await TestCourseService.AddStudentToCourse(MockStudent.Object, "NonExistingCourseName"));
        }

        public async Task AddingStudentToCourse_ShouldIncreaseCountOfStudentsOfCourse()
        {
            // Arrange

            // Act
            await TestCourseService.AddCourse(MockCourse.Object);
            await TestCourseService.AddStudentToCourse(MockStudent.Object, MockCourse.Object.GetCourseName());

            // Assert
            ClassicAssert.AreEqual(1, MockCourse.Object.GetStudentsCountOfCourse());
        }
        [Test]
        public async Task GetCourseStatistics_ShouldReturnStatistics()
        {
            // Arrange
            MockCourseRepository.Setup(repo => repo.GetCourseStatistics(TestCourseStaticticCourseName))
                .ReturnsAsync(MockCourseStatistic.Object);

            // Act
            var result = await TestCourseService.GetCourseStatistics(TestCourseStaticticCourseName);

            // Assert
            ClassicAssert.AreEqual(MockCourseStatistic.Object, result);
        }
    }
}
