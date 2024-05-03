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
    public class AdditionTest
    {
        private Addition addition;

        [SetUp]
        public void Setup()
        {
            addition = new Addition();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 8;

            // Act
            int actual = (int)addition.Add(a, b);

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
            int expected = -8;

            // Act
            int actual = (int)addition.Add(a, b);

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
            int expected = 8;

            // Act
            int actual = (int)addition.Add(a, b);

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
            double expected = 8.4;

            // Act
            double actual = addition.Add(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test the commutative property: a + b == b + a
        [Test]
        public void TestCommutativeProperty()
        {
            // Arrange
            double a = 5;
            double b = 3;

            // Act
            double ab = addition.Add(a, b);
            double ba = addition.Add(b, a);

            // Assert
            ClassicAssert.AreEqual(ab, ba);
        }
    }
}
