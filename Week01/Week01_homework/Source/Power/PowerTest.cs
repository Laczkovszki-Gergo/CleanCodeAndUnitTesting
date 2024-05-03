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
    internal class PowerTest
    {
        private Power power;

        [SetUp]
        public void Setup()
        {
            power = new Power();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 3;
            int b = 4;
            double expected = 81;

            // Act
            double actual = power.Pow(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with negative integers
        [Test]
        public void TestNegativeIntegers()
        {
            // Arrange
            int a = -2;
            int b = -1;
            double expected = -0.5;

            // Act
            double actual = power.Pow(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with zero as Base.
        [Test]
        public void TestZeroAsBase()
        {
            // Arrange
            int a = 0;
            int b = 8;
            double expected = 0;

            // Act
            double actual = power.Pow(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with zero as exponent.
        [Test]
        public void TestZeroAsExponent()
        {
            // Arrange
            int a = 8;
            int b = 0;
            int expected = 1;

            // Act
            double actual = power.Pow(a, b);

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
            double expected = 283.4448;

            // Act
            double actual = power.Pow(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test edge case scenarios with large numbers
        [Test]
        public void TestWithLargeNumbers()
        {
            // Arrange
            double a = 1000000000;
            double b = 1000000000;

            //Act & Assert
            ClassicAssert.Throws<OverflowException>(() => power.Pow(a, b));
        }
    }
}
