using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSetup.Source
{
    [TestFixture]
    internal class DivisionTest
    {
        private Division division;

        [SetUp]
        public void Setup()
        {
            division = new Division();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 15;
            int b = 3;
            int expected = 5;

            // Act
            double actual = division.Div(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with negative integers
        [Test]
        public void TestNegativeIntegers()
        {
            // Arrange
            int a = -15;
            int b = -3;
            int expected = 5;

            // Act
            double actual = division.Div(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with zero as Devided.
        [Test]
        public void TestZeroAsDevided()
        {
            // Arrange
            int a = 8;
            int b = 0;

            // Act & Assert
            ClassicAssert.Throws<DivideByZeroException>(() => division.Div(a, b));
        }

        //Test with zero as Devisor.
        [Test]
        public void TestZeroAsDevisor()
        {
            // Arrange
            int a = 0;
            int b = 8;
            int expected = 0;

            // Act
            double actual = division.Div(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test with floating-point numbers
        [Test]
        public void TestFloatingPointNumbers()
        {
            // Arrange
            double a = 4.8;
            double b = 3.6;
            double expected = 1.3333;

            // Act
            double actual = division.Div(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test scenarios where division by zero should throw an Error
        //Nem értem teljesen mi a feladat
        [Test]
        public void TestCommutativeProperty()
        {
            // Arrange
            double a = 5;
            double b = 0;

            // Act & Assert
            ClassicAssert.Throws<DivideByZeroException>(() => division.Div(a, b));
        }
    }
}
