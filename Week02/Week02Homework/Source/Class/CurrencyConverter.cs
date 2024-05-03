using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week02Homework.Source.Exceptions;

namespace Week02Homework.Source.Class
{
    public class CurrencyConverter
    {
        private readonly double FIXEDAMOUNT = 100;
        ExchangeRateService ExchangeRateService;
        public CurrencyConverter(ExchangeRateService exchangeRateService)
        {
            ExchangeRateService = exchangeRateService;
        }

        public virtual double Convert(double amount, Currency fromCurreny, Currency toCurrency)
        {
            ValidateAmount(amount);
            double exchangeRate = default;

            exchangeRate = ExchangeRateService.GetExchangeRate(fromCurreny, toCurrency);
            ValidateExchangeRate(exchangeRate);

            return amount * exchangeRate;
        }

        public string GenerateConversionReport(Currency fromCurrency, Currency toCurrency, DateTime StartDate, DateTime endDate)
        {
            List<double> conversions = new List<double>();

            DateTime currentDate = StartDate;

            while (currentDate <= endDate)
            {
                double exchangeRate = ExchangeRateService.GetExchangeRate(fromCurrency, toCurrency);
                ValidateExchangeRate(exchangeRate);
                CalculateConversion(exchangeRate, conversions, currentDate, out currentDate);
            }
            return $"Conversion Report:\n{string.Join("\n", conversions)}";
        }

        private List<double> CalculateConversion(double exchangeRate, List<double> conversions, DateTime currentDate, out DateTime backActualDate)
        {
            double convertedAmount = FIXEDAMOUNT * exchangeRate;
            ValidateAmount(convertedAmount);

            conversions.Add(convertedAmount);
            backActualDate = currentDate.Date.AddDays(1);
            return conversions;
        }

        private void ValidateExchangeRate(double exchangeRate)
        {
            if (exchangeRate == 0)
                throw new ServiceUnavailableException("Unable to fetch exchange rate.");

            if (double.IsNaN(exchangeRate))
                throw new ValidationException("Invalid exchange rate.");
        }

        private void ValidateAmount(double amount)
        {
            if (double.IsNaN(amount))
                throw new ValidationException("Invalid amount input.");
        }
    }
}
