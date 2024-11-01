using CurrencyApp.Core.Models;

namespace CurrencyApp.Infrastructure.Services
{
    public interface IExchangeRateRepo
    {
        HashSet<CurrencyRate> GetRates();
    }
}
