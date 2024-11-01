using CurrencyApp.Application.Interfaces;
using CurrencyApp.Infrastructure;
using CurrencyApp.Infrastructure.Services;
using System.Configuration;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Singleton class that caches available currency codes.
    /// </summary>
    public class AvailableCurrencyCodeCache : ICache
    {
        private static AvailableCurrencyCodeCache? instance = null;
        private static readonly object padlock = new();
        private readonly HashSet<string> _availableCodes;
        private readonly ICurrencyCodesRepo _currencyCodesRepo;

        /// <summary>
        /// Private constructor to prevent instantiation.
        /// Initializes the currency codes repository and loads available currency codes.
        /// </summary>
        private AvailableCurrencyCodeCache()
        {
            var path = ConfigurationManager.AppSettings["AvailableCurrenciesFilePath"];
            _currencyCodesRepo = new CurrencyCodesFromFile(path);
            _availableCodes = getAvailableCurrencyCodes()!;
        }

        /// <summary>
        /// Retrieves available currency codes from the repository.
        /// </summary>
        /// <returns>A HashSet of available currency codes.</returns>
        private HashSet<string>? getAvailableCurrencyCodes()
        {
            return _currencyCodesRepo.GetAvailableCurrencyCodes();
        }

        /// <summary>
        /// Gets the singleton instance of the AvailableCurrencyCodeCache.
        /// </summary>
        public static AvailableCurrencyCodeCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        instance ??= new AvailableCurrencyCodeCache();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets the cached available currency codes.
        /// </summary>
        /// <returns>A HashSet of available currency codes.</returns>
        public HashSet<string> GetAvailableCurrencyCodes()
        {
            return _availableCodes;
        }
    }
}
