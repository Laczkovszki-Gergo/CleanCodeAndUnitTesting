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
    public class UserInputValidatorTest
    {
        private UserInputValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new UserInputValidator();
        }

        [Test]
        public void TestValidInput()
        {
            // Arrange
            string input = "ValiD123";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsTrue(isValid);
        }

        [Test]
        public void TestEmptyInput()
        {
            // Arrange
            string input = "";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsFalse(isValid);
        }

        [Test]
        public void TestShortInput()
        {
            // Arrange
            string input = "Shrt";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsFalse(isValid);
        }

        [Test]
        public void TestLongInput()
        {
            // Arrange
            string input = "ThisIsAVeryLongInputString";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsFalse(isValid);
        }

        [Test]
        public void TestInvalidCharactersInput()
        {
            // Arrange
            string input = "Invalid$%Chars";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsFalse(isValid);
        }

        [Test]
        public void TestValidCharactersWithSpaceInput()
        {
            // Arrange
            string input = "Valid With Space";

            // Act
            bool isValid = validator.ValidateUserInput(input);

            // Assert
            ClassicAssert.IsFalse(isValid);
        }
    }
}
