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
    internal class SquareRootTest
    {
        private SquareRoot squareRoot;

        [SetUp]
        public void Setup()
        {
            squareRoot = new SquareRoot();
        }

        //Test with positive integers
        [Test]
        public void TestPositiveIntegers()
        {
            // Arrange
            int a = 9;
            int expected = 3;

            // Act
            double actual = squareRoot.Squ(a);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test with zero as Devided.
        [Test]
        public void TestZero()
        {
            // Arrange
            int a = 0;
            int expected = 0;

            // Act
            double actual = squareRoot.Squ(a);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        //Test scenarios where calculating the square root of a negative number should throw an Error
        [Test]
        public void TestNegativeIntegers()
        {
            // Arrange
            int a = -9;

            // Act & Assert
            ClassicAssert.Throws<ArgumentOutOfRangeException>(() => squareRoot.Squ(a));
        }
    }
}
