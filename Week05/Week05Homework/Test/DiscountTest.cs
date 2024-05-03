using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week05Homework.Source.Discount;
using static Week05Homework.Source.Enums;

namespace Week05Homework.Test.DiscountTest
{
    [TestFixture]
    public class DiscountTest
    {
        [TestCase(DiscountCalculatorLevel.Standard, ExpectedResult = 5)]
        [TestCase(DiscountCalculatorLevel.Silver, ExpectedResult = 10)]
        [TestCase(DiscountCalculatorLevel.Gold, ExpectedResult = 20)] // 15 + 5 additional discount for gold members
        [TestCase(DiscountCalculatorLevel.Unknown, ExpectedResult = 0)]
        public int CalculateDiscountPercentage_ShouldReturnCorrectDiscount(DiscountCalculatorLevel level)
        {
            DiscountProcessor processor = new DiscountProcessor();
            return processor.CalculateDiscountPercentage(level);
        }
    }
}
