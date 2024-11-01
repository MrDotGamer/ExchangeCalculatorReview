using CurrencyApp.Core.Models;
using CurrencyApp.Infrastructure.Services;
using CurrencyApp.UI.Interfaces;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Service for handling exchange rate operation.
    /// </summary>
    public class ExchangeRateService(IExchangeRateRepo exchangeRepo) : IExchangeRateService
    {
        private readonly IExchangeRateRepo _exchangeRepo = exchangeRepo;

        /// <summary>
        /// Gets the exchange rates.
        /// </summary>
        /// <returns>A set of currency rates.</returns>
        public HashSet<CurrencyRate> GetRates()
        {
            return _exchangeRepo.GetRates();
        }
    }
}
