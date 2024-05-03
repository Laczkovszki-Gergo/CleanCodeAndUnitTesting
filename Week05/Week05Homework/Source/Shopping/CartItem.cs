using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Shopping
{
    public interface ICartItem
    {
        decimal GetPrice();
    }

    public class CartItem : ICartItem
    {
        string Product;
        decimal Price;

        public CartItem(string product, decimal price)
        {
            Product = product;
            Price = price;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}
