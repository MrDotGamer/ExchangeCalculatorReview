namespace CurrencyApp.Core.Models
{
    /// <summary>
    /// Represents the exchange rate for a specific currency.
    /// </summary>
    public class CurrencyRate
    {
        /// <summary>
        /// Gets the currency code.
        /// </summary>
        public string CurrencyCode { get; init; }

        /// <summary>
        /// Gets the exchange rate for the currency.
        /// </summary>
        public decimal Rate { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRate"/> class.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="rate">The exchange rate.</param>
        private CurrencyRate(string currencyCode, decimal rate)
        {
            CurrencyCode = currencyCode;
            Rate = rate;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CurrencyRate"/> class with the specified currency code and rate.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="rate">The exchange rate.</param>
        /// <returns>A new instance of the <see cref="CurrencyRate"/> class.</returns>
        public static CurrencyRate Create(string currencyCode, decimal rate)
        {
            return new CurrencyRate(currencyCode.ToUpper(), rate);
        }
    }
}
