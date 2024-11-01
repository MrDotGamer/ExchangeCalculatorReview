using CurrencyApp.Core.Models;
using CurrencyApp.Infrastructure.Services;

namespace CurrencyApp.Infrastructure
{
    public class ExchangeRateRepoMock : IExchangeRateRepo
    {
        public HashSet<CurrencyRate> GetRates()
        {
            var rates = new (string, decimal)[]
            {
                    ("EUR", 7.4394M),
                    ("USD", 6.6311M),
                    ("GBP", 8.5285M),
                    ("SEK", 0.7610M),
                    ("NOK", 0.7840M),
                    ("CHF", 6.8358M),
                    ("JPY", 0.059740M),
                    ("DKK", 1M)
            };

            var currencyRates = new HashSet<CurrencyRate>(rates.Length);

            foreach (var (currency, rate) in rates)
            {
                currencyRates.Add(CurrencyRate.Create(currency, rate));
            }

            return currencyRates;
        }
    }
}
