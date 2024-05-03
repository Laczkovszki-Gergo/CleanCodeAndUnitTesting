using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Exceptions;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Test.FinancialApiClientTest
{
    [TestFixture]
    public class FinancialApiClientTests
    {
        FinancialApiClient FinancialApiClient;
        Mock<Course> MockCourse;
        Mock<Student> MockStudent;

        [SetUp]
        public void Setup()
        {
            FinancialApiClient = new FinancialApiClient();
            MockCourse = new Mock<Course>();
            MockStudent = new Mock<Student>();
        }

        [Test]
        public async Task CheckPaymentStatus_ValidStudentAndCourse_ReturnsTrue()
        {
            // Arrange

            // Act
            var result = await FinancialApiClient.CheckPaymentStatus(MockStudent.Object, MockCourse.Object);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task PayForCourse_ValidStudentAndCourse_ReturnsTrue()
        {
            // Arrange

            // Act
            var result = await FinancialApiClient.PayForCourse(MockStudent.Object, MockCourse.Object);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void CheckPaymentStatus_NullStudent_ThrowsArgumentNullException()
        {
            // Arrange

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => FinancialApiClient.CheckPaymentStatus(null, new Course()));
        }

        [Test]
        public void CheckPaymentStatus_NullCourse_ThrowsArgumentNullException()
        {
            // Arrange

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => FinancialApiClient.CheckPaymentStatus(MockStudent.Object, null));
        }

        [Test]
        public void PayForCourse_NullStudent_ThrowsArgumentNullException()
        {
            // Arrange

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => FinancialApiClient.PayForCourse(null, new Course()));
        }

        [Test]
        public void PayForCourse_NullCourse_ThrowsArgumentNullException()
        {
            // Arrange

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => FinancialApiClient.PayForCourse(MockStudent.Object, null));
        }
    }
}
