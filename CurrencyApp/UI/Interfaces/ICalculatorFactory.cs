using CurrencyApp.Application.Services;

namespace CurrencyApp.UI.Interfaces
{
    /// <summary>
    /// Interface for creating calculator instances.
    /// </summary>
    public interface ICalculatorFactory
    {
        /// <summary>
        /// Creates an instance of a calculator for currency exchange.
        /// </summary>
        /// <returns>A new instance of <see cref="ExchangeCalculator"/>.</returns>
        ExchangeCalculator CreateExchangeCalculator();
    }
}
