using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02Homework.Source.Class
{
    public class Currency
    {
        public string Name { get; set; }
        public double ExchangeRateToFt { get; set; }

        public Currency(string name, double exchangeRateToFt)
        {
            Name = name;
            ExchangeRateToFt = exchangeRateToFt;
        }
    }
}
