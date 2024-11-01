using CurrencyApp.Core.Models;

namespace CurrencyApp.Application.Interfaces
{
    /// <summary>
    /// Represents a token that contains information about currency conversion.
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Gets the currency to convert from.
        /// </summary>
        public Currency CurrencyFrom { get; init; }

        /// <summary>
        /// Gets the currency to convert to.
        /// </summary>
        public Currency CurrencyTo { get; init; }

        /// <summary>
        /// Gets the calculator operation to perform the conversion.
        /// </summary>
        public ICalculatorOperation CalculatorOperation { get; init; }
    }
}
