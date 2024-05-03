using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week05Homework.Source.Shopping;

namespace Week05Homework.Test
{
    [TestFixture]
    public class PurchaseAmountCalculatorTests
    {
        [Test]
        public void CalculateTotal_ShouldReturnCorrectTotal_WhenCartHasItems()
        {
            // Arrange
            var cartItems = new List<ICartItem>
        {
            new CartItem("CartItem1", 10),
            new CartItem("CartItem2", 20)
        };

            var shoppingCartMock = new Mock<IShoppingCart>();
            shoppingCartMock.Setup(x => x.GetCartItems()).Returns(cartItems);

            var purchaseAmountCalculator = new PurchaseAmountCalculator(shoppingCartMock.Object);

            // Act
            var total = purchaseAmountCalculator.CalculateTotal();

            // Assert
            ClassicAssert.AreEqual(30, total);
        }

        [Test]
        public void CalculateTotal_ShouldReturnZero_WhenCartIsEmpty()
        {
            // Arrange
            var cartItems = new List<ICartItem>();

            var shoppingCartMock = new Mock<IShoppingCart>();
            shoppingCartMock.Setup(x => x.GetCartItems()).Returns(cartItems);

            var purchaseAmountCalculator = new PurchaseAmountCalculator(shoppingCartMock.Object);

            // Act
            var total = purchaseAmountCalculator.CalculateTotal();

            // Assert
            ClassicAssert.AreEqual(0, total);
        }

        [Test]
        public void CalculateTotal_ShouldReturnZero_WhenCartIsNull()
        {
            // Arrange
            IShoppingCart nullCart = null;
            var purchaseAmountCalculator = new PurchaseAmountCalculator(nullCart);

            // Act
            var total = purchaseAmountCalculator.CalculateTotal();

            // Assert
            ClassicAssert.AreEqual(0, total);
        }
    }
}
