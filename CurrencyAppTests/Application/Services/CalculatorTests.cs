using CurrencyApp.Application.Interfaces;
using CurrencyApp.Application.Models;
using CurrencyApp.Application.Services;
using CurrencyApp.Core.Models;
using Moq;

namespace CurrencyAppTests.Application.Services
{
    [TestFixture]
    public class CalculatorTests
    {
        private ExchangeCalculator _calculator;
        private Mock<ICalculatorOperation> _mockOperation;
        private HashSet<CurrencyRate> _rates;
        private Mock<IToken> _mockToken;
        private Currency _currencyFrom;
        private Currency _currencyTo;

        [SetUp]
        public void SetUp()
        {
            _mockOperation = new Mock<ICalculatorOperation>();
            _calculator = ExchangeCalculator.Create();
            _rates =
            [
                CurrencyRate.Create("USD", 1.0m ),
                CurrencyRate.Create("EUR", 0.85m)
            ];
            _currencyFrom = Currency.Create("USD", "100");
            _currencyTo = Currency.Create("EUR", "0");
            _mockToken = new Mock<IToken>();
            _mockToken.Setup(t => t.CalculatorOperation).Returns(new ExchangeOperation());
            _mockToken.Setup(t => t.CurrencyFrom).Returns(_currencyFrom);
            _mockToken.Setup(t => t.CurrencyTo).Returns(_currencyTo);
        }

        [Test]
        public void Calculate_WithValidOperation_PerformsCalculation()
        {
            // Arrange
            _mockOperation.Setup(o => o.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(85m);
            _calculator = ExchangeCalculator.Create();
            _calculator.GetType().GetField("_operations", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .SetValue(_calculator, new Dictionary<string, ICalculatorOperation> { { "/", _mockOperation.Object } });

            // Act
            _calculator.Calculate(_rates, _mockToken.Object);

            // Assert
            Assert.That(_calculator.CalculationResult, Is.EqualTo("100 USD = 85 EUR"));
            _mockToken.Verify(t => t.CurrencyTo.UpdateAmount(85m), Times.Once);
        }

        [Test]
        public void Calculate_WithMissingFromRate_ThrowsException()
        {
            // Arrange
            _mockToken.Setup(t => t.CurrencyFrom).Returns(Currency.Create("GBP", "100"));

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _calculator.Calculate(_rates, _mockToken.Object));
            Assert.That(ex.Message, Is.EqualTo("Currency rate from is not available"));
        }

        [Test]
        public void Calculate_WithMissingToRate_ThrowsException()
        {
            // Arrange
            _mockToken.Setup(t => t.CurrencyTo).Returns(Currency.Create("GBP", ""));

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _calculator.Calculate(_rates, _mockToken.Object));
            Assert.That(ex.Message, Is.EqualTo("Currency rate to is not available"));
        }
    }
}
