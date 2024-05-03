using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week05Homework.Source.Enums;

namespace Week05Homework.Source.Discount
{
    public abstract class DiscountCalculator
    {
        public abstract int CalculateDiscountPercentage(DiscountCalculatorLevel level);
    }

    public class StandardDiscountCalculator : DiscountCalculator
    {
        public override int CalculateDiscountPercentage(DiscountCalculatorLevel level)
        {
            if (level == DiscountCalculatorLevel.Standard)
                return 5;

            return 0;
        }
    }

    public class SilverDiscountCalculator : DiscountCalculator
    {
        public override int CalculateDiscountPercentage(DiscountCalculatorLevel level)
        {
            if (level == DiscountCalculatorLevel.Silver)
                return 10;

            return 0;
        }
    }

    public class GoldDiscountCalculator : DiscountCalculator
    {
        public override int CalculateDiscountPercentage(DiscountCalculatorLevel level)
        {
            if (level == DiscountCalculatorLevel.Gold)
                return 15 + 5; // Additional discount for gold members

            return 0;
        }
    }
}