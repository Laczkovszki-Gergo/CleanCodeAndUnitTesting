using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week05Homework.Source;
using Week05Homework.Source.Discount;
using Week05Homework.Source.Shopping;
using static Week05Homework.Source.Enums;

namespace Week05Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiscountProcessor processor = new DiscountProcessor();

            // Kedvezmény számítása a különböző szintű tagsági szintekre
            Console.WriteLine("Standard: " + processor.CalculateDiscountPercentage(DiscountCalculatorLevel.Standard));
            Console.WriteLine("Silver: " + processor.CalculateDiscountPercentage(DiscountCalculatorLevel.Silver));
            Console.WriteLine("Gold: " + processor.CalculateDiscountPercentage(DiscountCalculatorLevel.Gold));
            Console.WriteLine("Unknown: " + processor.CalculateDiscountPercentage(DiscountCalculatorLevel.Unknown));


            // Kosár létrehozása
            ShoppingCart shoppingCart = new ShoppingCart();

            // Termékek hozzáadása a kosárhoz
            shoppingCart.AddCartItem(new CartItem("CartItem1", 10.5m));
            shoppingCart.AddCartItem(new CartItem("CartItem2", 20.3m));

            // Vásárlás összegének kiszámítása
            PurchaseAmountCalculator purchaseAmountCalculator = new PurchaseAmountCalculator(shoppingCart);
            decimal total = purchaseAmountCalculator.CalculateTotal();

            // Eredmény kimenetének megjelenítése
            Console.WriteLine("Total purchase amount: " + total);


            Console.ReadKey();
        }
    }
}
