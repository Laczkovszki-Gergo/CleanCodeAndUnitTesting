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
    internal class SubtractionTest
    {
        private Subtraction subtraction;

        [SetUp]
        public void Setup()
        {
            subtraction = new Subtraction();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 2;

            // Act
            int actual = (int)subtraction.Sub(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with negative integers
        [Test]
        public void TestNegativeIntegers()
        {
            // Arrange
            int a = -5;
            int b = -3;
            int expected = -2;

            // Act
            int actual = (int)subtraction.Sub(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }
        //Test with zero.
        [Test]
        public void TestZero()
        {
            // Arrange
            int a = 0;
            int b = 8;
            int expected = -8;

            // Act
            int actual = (int)subtraction.Sub(a, b);

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
            double expected = 1.2;

            // Act
            double actual = Math.Round(subtraction.Sub(a, b), 2);
            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test the commutative property: a - b == b - a
        [Test]
        public void TestCommutativeProperty()
        {
            // Arrange
            double a = 5;
            double b = 3;

            // Act
            double ab = subtraction.Sub(a, b);
            double ba = subtraction.Sub(b, a);

            // Assert
            ClassicAssert.Greater(ab, ba);
            ClassicAssert.Less(ba, ab);
        }
    }
}
