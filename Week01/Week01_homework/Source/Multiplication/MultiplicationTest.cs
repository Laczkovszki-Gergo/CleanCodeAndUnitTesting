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
    internal class MultiplicationTest
    {
        private Multiplication multiplication;

        [SetUp]
        public void Setup()
        {
            multiplication = new Multiplication();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 15;

            // Act
            int actual = (int)multiplication.Mul(a, b);

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
            int expected = 15;

            // Act
            int actual = (int)multiplication.Mul(a, b);

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
            int expected = 0;

            // Act
            int actual = (int)multiplication.Mul(a, b);

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
            double expected = 17.28;

            // Act
            double actual = multiplication.Mul(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test the commutative property: a * b == b * a
        [Test]
        public void TestCommutativeProperty()
        {
            // Arrange
            double a = 5;
            double b = 3;

            // Act
            double ab = multiplication.Mul(a, b);
            double ba = multiplication.Mul(b, a);

            // Assert
            ClassicAssert.AreEqual(ab, ba);
        }
    }
}
