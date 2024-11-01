using CurrencyApp.Application.Services;
using CurrencyApp.Infrastructure;
using CurrencyApp.Infrastructure.Services;
using CurrencyApp.UI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyApp.UI.Extensions
{
    public static class ExchangeServiceProviderExtension
    {
        public static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IExchangeRateService, ExchangeRateService>()
                .AddTransient<IExchangeRateRepo, ExchangeRateRepoMock>()
                .BuildServiceProvider();
        }
    }
}
