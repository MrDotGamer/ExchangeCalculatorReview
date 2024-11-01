namespace CurrencyApp.Application.Interfaces
{
    /// <summary>
    /// Defines the interface for a calculator operation.
    /// </summary>
    public interface ICalculatorOperation
    {
        /// <summary>
        /// Gets the name of the calculator operation.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Calculates the result of a currency conversion operation.
        /// </summary>
        /// <param name="fromRate">The exchange rate of the source currency.</param>
        /// <param name="toRate">The exchange rate of the target currency.</param>
        /// <param name="amount">The amount of currency to convert.</param>
        /// <returns>The result of the currency conversion.</returns>
        decimal Calculate(decimal fromRate, decimal toRate, decimal amount);
    }
}
