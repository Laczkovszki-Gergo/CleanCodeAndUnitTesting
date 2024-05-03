using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week02Homework.Source.Exceptions;
using Week02Homework.Source.Interface;

namespace Week02Homework.Source.Class
{
    public class ExchangeRateService : IExchangeRateService
    {
        public virtual double GetExchangeRate(Currency fromCurrency, Currency toCurrency)
        {
            try
            {
                return toCurrency.ExchangeRateToFt / fromCurrency.ExchangeRateToFt;
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                    throw new NullReferenceException("No value provided");
                else if (ex is DivideByZeroException)
                    throw new DivideByZeroException("Division by zero occurred.");
                throw new UnkownException("An unknown error occurred.");
            }
        }
    }
}
