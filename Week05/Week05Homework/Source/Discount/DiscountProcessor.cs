using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week05Homework.Source.Enums;

namespace Week05Homework.Source.Discount
{
    public class DiscountProcessor
    {
        private Dictionary<DiscountCalculatorLevel, DiscountCalculator> calculatorMap;
        public DiscountProcessor()
        {
            calculatorMap = new Dictionary<DiscountCalculatorLevel, DiscountCalculator>
            {
                { DiscountCalculatorLevel.Standard, new StandardDiscountCalculator() },
                { DiscountCalculatorLevel.Silver, new SilverDiscountCalculator() },
                { DiscountCalculatorLevel.Gold, new GoldDiscountCalculator() }
            };
        }

        public int CalculateDiscountPercentage(DiscountCalculatorLevel level)
        {
            // Ellenőrizzük, hogy a level értéke szerepel-e a Dictionary-ben
            if (calculatorMap.ContainsKey(level))
                // Ha igen, akkor hívjuk meg a megfelelő DiscountCalculator osztály CalculateDiscountPercentage metódusát
                return calculatorMap[level].CalculateDiscountPercentage(level);

            // Ha nem találjuk a megfelelő kedvezmény típust, akkor nincs kedvezmény
            return 0;
        }
    }
}
