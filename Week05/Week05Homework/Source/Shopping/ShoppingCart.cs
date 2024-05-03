using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Shopping
{
    public interface IShoppingCart
    {
        void AddCartItem(ICartItem cartItem);
        List<ICartItem> GetCartItems();
    }

    public class ShoppingCart : IShoppingCart
    {
        private List<ICartItem> CartItems = new List<ICartItem>();

        public void AddCartItem(ICartItem cartItem)
        {
            CartItems.Add(cartItem);
        }

        public List<ICartItem> GetCartItems()
        {
            return CartItems;
        }
    }
}
