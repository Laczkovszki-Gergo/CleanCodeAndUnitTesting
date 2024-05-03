using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week04Homework.Source;

namespace Week04Homework.UnitTest
{
    [TestFixture]
    public class UserDataProcessorTest
    {
        private UserDataProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new UserDataProcessor();
        }

        [Test]
        public void TestShouldReturnWithUserFound()
        {
            // Arrange
            var userData = new UserRequest
            {
                IsUserSearchRequested = true,
                IsDataProcessingRequested = true,
                UserList = new string[] { "user1", "user2", "user3" },
                SearchTerm = "user2",
                ProcessingIterations = 0
            };
            string expectedResult = "User found: user2";

            // Act
            string result = processor.ProcessUserData(userData);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestShouldReturnWithProcessing()
        {
            // Arrange
            var userData = new UserRequest
            {
                IsUserSearchRequested = false,
                IsDataProcessingRequested = true,
                UserList = new string[] { },
                SearchTerm = "",
                ProcessingIterations = 3
            };
            string expectedResult = "Processing... Processing... Processing... ";

            // Act
            string result = processor.ProcessUserData(userData);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestShouldReturnWithNoActionTaken()
        {
            // Arrange
            var userData = new UserRequest
            {
                IsUserSearchRequested = false,
                IsDataProcessingRequested = false,
                UserList = new string[] { },
                SearchTerm = "",
                ProcessingIterations = 0
            };
            string expectedResult = "No action taken.";

            // Act
            string result = processor.ProcessUserData(userData);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
        }
    }
}
