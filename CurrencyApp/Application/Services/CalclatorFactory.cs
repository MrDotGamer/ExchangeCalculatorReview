using CurrencyApp.UI.Interfaces;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Factory class for creating instances of ExchangeCalculator.
    /// </summary>
    public class CalclatorFactory : ICalculatorFactory
    {
        /// <summary>
        /// Creates a new instance of ExchangeCalculator.
        /// </summary>
        /// <returns>A new instance of ExchangeCalculator.</returns>
        public ExchangeCalculator CreateExchangeCalculator()
        {
            return ExchangeCalculator.Create();
        }
    }
}
