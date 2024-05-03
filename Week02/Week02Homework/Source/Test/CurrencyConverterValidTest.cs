using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week02Homework.Source.Class;
using Week02Homework.Source.Exceptions;
using Snapper;

namespace Week02Homework.Source.Test
{
    [TestFixture]
    public class CurrencyConverterValidTest
    {
        CurrencyConverter currencyConverter;
        Mock<ExchangeRateService> mockExchangeRateService;
        readonly Currency fromCurrency = new Currency("EUR", 393);
        readonly Currency toCurrency = new Currency("USD", 364);
        readonly double amount = 100;

        [SetUp]
        public void SetUp()
        {
            mockExchangeRateService = new Mock<ExchangeRateService>();
            currencyConverter = new CurrencyConverter(mockExchangeRateService.Object);
        }

        #region TestConvertFunction
        [Test]
        [Category("ValidConvertTests")]
        public void ConvertValidInputReturnsCorrectAmount()
        {
            //Arrange
            double expected = 0.93;
            mockExchangeRateService.Setup(x => x.GetExchangeRate(It.IsAny<Currency>(), It.IsAny<Currency>())).Returns(expected);
            // Act
            var result = currencyConverter.Convert(amount, fromCurrency, toCurrency);

            // Assert
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.Once());
            ClassicAssert.AreEqual(expected * amount, result);
        }
        #endregion

        #region TestGenerateFunction
        [Test]
        [Category("ValidGenerateConversionTests")]
        public void GenerateConversionReportValidInputReturnsCorrectReport()
        {
            //Arrange
            double expected = 0.93;
            mockExchangeRateService.Setup(x => x.GetExchangeRate(It.IsAny<Currency>(), It.IsAny<Currency>())).Returns(expected);

            // Act
            var result = currencyConverter.GenerateConversionReport(fromCurrency, toCurrency, DateTime.Now.Date, DateTime.Now.Date.AddDays(2));

            // Assert
            result.ShouldMatchSnapshot();
            ClassicAssert.AreEqual("Conversion Report:\n93\n93\n93", result);
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.AtLeastOnce());
        }
        #endregion
    }
}
