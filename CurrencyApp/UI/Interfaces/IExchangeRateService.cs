using CurrencyApp.Core.Models;

namespace CurrencyApp.UI.Interfaces
{
    /// <summary>
    /// Interface for retrieving exchange rates.
    /// </summary>
    public interface IExchangeRateService
    {
        /// <summary>
        /// Gets the current exchange rates.
        /// </summary>
        /// <returns>A HashSet of CurrencyRate objects representing the current exchange rates.</returns>
        HashSet<CurrencyRate> GetRates();
    }
}
