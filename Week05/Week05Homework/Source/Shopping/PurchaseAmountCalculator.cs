using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Shopping
{
    public interface IPurchaseAmountCalculator
    {
        decimal CalculateTotal();
    }

    public class PurchaseAmountCalculator : IPurchaseAmountCalculator
    {
        IShoppingCart ShoppingCart;
        public PurchaseAmountCalculator(IShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public decimal CalculateTotal()
        {
            if (ShoppingCart == null)            
                return 0;            

            decimal total = 0;
            foreach (var cartItem in ShoppingCart.GetCartItems())
            {
                total += cartItem.GetPrice();
            }
            return total;
        }
    }
}
