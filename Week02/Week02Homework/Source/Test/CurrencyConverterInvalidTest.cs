using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Snapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week02Homework.Source.Class;
using Week02Homework.Source.Exceptions;

namespace Week02Homework.Source.Test
{
    [TestFixture]
    internal class CurrencyConverterInvalidTest
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
        [Category("InvalidConvertTests")]
        public void ConvertInvalidInputShouldThrowServiceUnavailableException()
        {
            //Arrange
            string errorMessage = "Unable to fetch exchange rate.";
            var expectedException = new ServiceUnavailableException(errorMessage);
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            //Act & Assert
            var ex = Assert.Throws<ServiceUnavailableException>(() => currencyConverter.Convert(amount, fromCurrency, toCurrency));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.Once());
            ClassicAssert.AreEqual(expectedException, ex);
        }

        [Test]
        [Category("InvalidConvertTests")]
        public void ConvertNullInputShouldThrowNullReferenceException()
        {
            //Arrange
            var expectedException = new NullReferenceException();
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            //Act & Assert
            var ex = Assert.Throws<NullReferenceException>(() => currencyConverter.Convert(amount, fromCurrency, toCurrency));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.Once());
            ClassicAssert.AreEqual(expectedException, ex);
        }
        [Test]
        [Category("InvalidConvertTests")]
        public void ConvertWithZeroDeviderInputShouldThrowDevideByZeroException()
        {
            //Arrange
            var expectedException = new DivideByZeroException();
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            //Act & Assert
            var ex = Assert.Throws<DivideByZeroException>(() => currencyConverter.Convert(amount, fromCurrency, toCurrency));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.Once());
            ClassicAssert.AreEqual(expectedException, ex);
        }

        [Test]
        [Category("InvalidConvertTests")]
        public void ConvertWithZeroDeviderInputShouldThrowUnknownException()
        {
            //Arrange
            string errorMessage = "An unknown error occurred.";
            var expectedException = new UnkownException(errorMessage);
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            //Act & Assert
            var ex = Assert.Throws<UnkownException>(() => currencyConverter.Convert(amount, fromCurrency, toCurrency));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.Once());
            ClassicAssert.AreEqual(expectedException, ex);
        }
        #endregion

        #region TestGenerateConvertFunction
        [Test]
        [Category("InvalidGenerateConversionTests")]
        public void GenerateConversionReportInputShouldThrowServiceUnavailableException()
        {
            //Arrange
            string errorMessage = "Unable to fetch exchange rate.";
            var expectedException = new ServiceUnavailableException(errorMessage);
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            // Act & Assert
            var ex = Assert.Throws<ServiceUnavailableException>(() => currencyConverter.GenerateConversionReport(fromCurrency, toCurrency, DateTime.Now.Date, DateTime.Now.Date.AddDays(2)));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.AtLeastOnce());
            ClassicAssert.AreEqual(expectedException, ex);
        }

        [Test]
        [Category("InvalidGenerateConversionTests")]
        public void GenerateConversionReportInputShouldThrowNullReferenceException()
        {
            //Arrange
            var expectedException = new NullReferenceException();
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            // Act & Assert
            var ex = Assert.Throws<NullReferenceException>(() => currencyConverter.GenerateConversionReport(fromCurrency, toCurrency, DateTime.Now.Date, DateTime.Now.Date.AddDays(2)));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.AtLeastOnce());
            ClassicAssert.AreEqual(expectedException, ex);
        }
        [Test]
        [Category("InvalidGenerateConversionTests")]
        public void GenerateConversionReportInputShouldThrowValidationException()
        {
            //Arrange
            string errorMessage = "Invalid exchange rate.";
            var expectedException = new ValidationException(errorMessage);
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            // Act & Assert
            var ex = Assert.Throws<ValidationException>(() => currencyConverter.GenerateConversionReport(fromCurrency, toCurrency, DateTime.Now.Date, DateTime.Now.Date.AddDays(2)));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.AtLeastOnce());
            ClassicAssert.AreEqual(expectedException, ex);
        }

        [Test]
        [Category("InvalidGenerateConversionTests")]
        public void GenerateConversionReportInputShouldThrowUnknownException()
        {
            //Arrange
            string errorMessage = "An unknown error occurred.";
            var expectedException = new UnkownException(errorMessage);
            mockExchangeRateService.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(expectedException);

            // Act & Assert
            var ex = Assert.Throws<UnkownException>(() => currencyConverter.GenerateConversionReport(fromCurrency, toCurrency, DateTime.Now.Date, DateTime.Now.Date.AddDays(2)));
            mockExchangeRateService.Verify(x => x.GetExchangeRate(fromCurrency, toCurrency), Times.AtLeastOnce());
            ClassicAssert.AreEqual(expectedException, ex);
        }
        #endregion
    }
}
