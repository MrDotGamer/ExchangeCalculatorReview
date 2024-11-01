using CurrencyApp.Application.Interfaces;

namespace CurrencyApp.Application.Models
{
    /// <summary>
    /// Represents an exchange operation that implements the ICalculatorOperation interface.
    /// </summary>
    public class ExchangeOperation : ICalculatorOperation
    {
        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        public string Name { get; } = "/";

        /// <summary>
        /// Calculates the result of the exchange operation.
        /// </summary>
        /// <param name="fromRate">The rate of the currency to convert from.</param>
        /// <param name="toRate">The rate of the currency to convert to.</param>
        /// <param name="amount">The amount of currency to convert.</param>
        /// <returns>The converted amount.</returns>
        public decimal Calculate(decimal fromRate, decimal toRate, decimal amount)
        {
            return amount * fromRate / toRate;
        }
    }
}
