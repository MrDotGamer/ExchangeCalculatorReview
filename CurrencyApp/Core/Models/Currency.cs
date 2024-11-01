using CurrencyApp.Application.Exceptions;
using CurrencyApp.Application.Services;

namespace CurrencyApp.Core.Models
{
    /// <summary>
    /// Represents a currency with a code and an amount.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets the currency code.
        /// </summary>
        public string CurrencyCode { get; init; }

        /// <summary>
        /// Gets the amount of the currency.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amount">The amount of the currency.</param>
        private Currency(string currencyCode, decimal amount)
        {
            CurrencyCode = currencyCode.ToUpper();
            Amount = amount;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amount">The amount of the currency as a string.</param>
        /// <returns>A new instance of the <see cref="Currency"/> class.</returns>
        /// <exception cref="AlphabeticCountryCodeValidationException">
        /// Thrown when the currency code is not valid.
        /// </exception>
        /// <exception cref="ParseCurrencyArgumentsException">
        /// Thrown when the amount cannot be parsed to a decimal.
        /// </exception>
        public static Currency Create(string currencyCode, string amount)
        {
            if (!AvailableCurrencyCodeCache.Instance.GetAvailableCurrencyCodes().Contains(currencyCode.ToUpper()))
            {
                throw new AlphabeticCountryCodeValidationException();
            }

            amount = fixSeparator(amount);

            if (!decimal.TryParse(amount, out decimal result))
            {
                throw new ParseCurrencyArgumentsException();
            }

            return new Currency(currencyCode, result);
        }

        /// <summary>
        /// Updates the amount of the currency.
        /// </summary>
        /// <param name="amount">The new amount of the currency.</param>
        public void UpdateAmount(decimal amount)
        {
            Amount = amount;
        }

        /// <summary>
        /// Fixes the separator in the amount string.
        /// </summary>
        /// <param name="amount">The amount string.</param>
        /// <returns>The fixed amount string.</returns>
        private static string fixSeparator(string amount)
        {
            return amount.Replace(",", ".").TrimEnd('.', ',');
        }
    }
}
