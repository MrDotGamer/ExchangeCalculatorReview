using CurrencyApp.Application.Interfaces;
using CurrencyApp.Application.Models;
using CurrencyApp.Core.Models;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Provides functionality to perform currency exchange calculations.
    /// </summary>
    public class ExchangeCalculator
    {
        /// <summary>
        /// Gets the result of the calculation.
        /// </summary>
        public string CalculationResult { get; private set; } = string.Empty;

        private readonly Dictionary<string, ICalculatorOperation> _operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeCalculator"/> class.
        /// </summary>
        private ExchangeCalculator()
        {
            _operations = new Dictionary<string, ICalculatorOperation>
                {
                    { "/", new ExchangeOperation() }
                };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExchangeCalculator"/> class.
        /// </summary>
        /// <returns>A new instance of the <see cref="ExchangeCalculator"/> class.</returns>
        public static ExchangeCalculator Create()
        {
            return new ExchangeCalculator();
        }

        /// <summary>
        /// Performs a currency exchange calculation based on the provided rates and token.
        /// </summary>
        /// <param name="rates">A set of currency rates.</param>
        /// <param name="token">The token containing the calculation details.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="Exception">Thrown when the currency rate is not available.</exception>
        public void Calculate(HashSet<CurrencyRate> rates, IToken token)
        {
            if (!_operations.TryGetValue(token.CalculatorOperation.Name, out var operation))
            {
                throw new InvalidOperationException("Invalid operation");
            }

            var fromRate = rates.FirstOrDefault(r => r.CurrencyCode == token.CurrencyFrom.CurrencyCode)?.Rate ?? throw new Exception("Currency rate from is not available");
            var toRate = rates.FirstOrDefault(r => r.CurrencyCode == token.CurrencyTo.CurrencyCode)?.Rate ?? throw new Exception("Currency rate to is not available");

            var convertedAmount = operation.Calculate(fromRate, toRate, token.CurrencyFrom.Amount);

            token.CurrencyTo.UpdateAmount(convertedAmount);

            CalculationResult = $"{token.CurrencyFrom.Amount} {token.CurrencyFrom.CurrencyCode} = {convertedAmount} {token.CurrencyTo.CurrencyCode}";
        }
    }
}
