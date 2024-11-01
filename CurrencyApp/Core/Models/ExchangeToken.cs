using CurrencyApp.Application.Interfaces;
using CurrencyApp.Application.Models;

namespace CurrencyApp.Core.Models
{
    /// <summary>
    /// Represents a token for currency exchange operations.
    /// </summary>
    public class ExchangeToken : IToken
    {
        /// <summary>
        /// Gets the source currency for the exchange.
        /// </summary>
        public Currency CurrencyFrom { get; init; }

        /// <summary>
        /// Gets the target currency for the exchange.
        /// </summary>
        public Currency CurrencyTo { get; init; }

        /// <summary>
        /// Gets the calculator operation for the exchange.
        /// </summary>
        public ICalculatorOperation CalculatorOperation { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeToken"/> class.
        /// </summary>
        /// <param name="input">An array of strings containing the currency codes and amounts.</param>
        private ExchangeToken(string[] input)
        {
            CurrencyFrom = Currency.Create(input[0], input[2]);
            CurrencyTo = Currency.Create(input[1], "0");
            CalculatorOperation = new ExchangeOperation();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExchangeToken"/> class.
        /// </summary>
        /// <param name="input">An array of strings containing the currency codes and amounts.</param>
        /// <returns>A new instance of the <see cref="ExchangeToken"/> class.</returns>
        public static ExchangeToken Create(string[] input)
        {
            return new ExchangeToken(input);
        }
    }
}
