using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Abstraction.Services;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Test.PaymentServiceTest
{
    [TestFixture]
    public class PaymentServiceTests
    {
        private Mock<IFinancialApiClient> MockFinancialApiClient;
        private PaymentService PaymentService;
        private Mock<Lecturer> MockLecturer;
        private Student Student;
        private Course Course;

        [SetUp]
        public void Setup()
        {
            MockFinancialApiClient = new Mock<IFinancialApiClient>();
            MockLecturer = new Mock<Lecturer>();
            PaymentService = new PaymentService(MockFinancialApiClient.Object);
            Student = new Student("John Doe", DateTime.Now, "123 Elm St", "john@example.com", "S00001", DateTime.Now);
            Course = new Course(MockLecturer.Object, "Test Course", DateTime.Now, 6, 50000);
        }

        [Test]
        public async Task GetIsOrderPayed_ShouldReturnTrue_WhenPaymentSuccessful()
        {
            // Arrange
            MockFinancialApiClient.Setup(x => x.CheckPaymentStatus(Student, Course)).ReturnsAsync(true);

            // Act
            var result = await PaymentService.GetIsOrderPayed(Student, Course);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task GetIsOrderPayed_ShouldReturnFalse_WhenPaymentFails()
        {
            // Arrange
            MockFinancialApiClient.Setup(x => x.CheckPaymentStatus(Student, Course)).ReturnsAsync(false);

            // Act
            var result = await PaymentService.GetIsOrderPayed(Student, Course);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public async Task PayForCourse_ShouldReturnTrue_WhenPaymentSuccessful()
        {
            // Arrange
            MockFinancialApiClient.Setup(x => x.PayForCourse(Student, Course)).ReturnsAsync(true);

            // Act
            var result = await PaymentService.PayForCourse(Student, Course);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task PayForCourse_ShouldReturnFalse_WhenPaymentFails()
        {
            // Arrange
            MockFinancialApiClient.Setup(x => x.PayForCourse(Student, Course)).ReturnsAsync(false);

            // Act
            var result = await PaymentService.PayForCourse(Student, Course);

            // Assert
            ClassicAssert.IsFalse(result);
        }
    }
}
