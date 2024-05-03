using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week02Homework.Source.Class;

namespace Week02Homework.Source.Interface
{
    public interface IExchangeRateService
    {
        double GetExchangeRate(Currency fromCurrency, Currency toCurrency);
    }
}
