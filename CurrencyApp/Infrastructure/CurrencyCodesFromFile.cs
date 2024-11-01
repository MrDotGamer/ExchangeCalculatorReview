using CurrencyApp.Infrastructure.Services;
using System.Xml.Linq;

namespace CurrencyApp.Infrastructure
{
    /// <summary>
    /// Provides functionality to retrieve currency codes from an XML file.
    /// </summary>
    public class CurrencyCodesFromFile : ICurrencyCodesRepo
    {
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyCodesFromFile"/> class with the specified file path.
        /// </summary>
        /// <param name="path">The relative path to the XML file containing currency codes.</param>
        public CurrencyCodesFromFile(string path) => filePath = pathCombine(AppContext.BaseDirectory, path);

        /// <summary>
        /// Gets the available currency codes from the XML file.
        /// </summary>
        /// <returns>A <see cref="HashSet{T}"/> containing the available currency codes.</returns>
        public HashSet<string> GetAvailableCurrencyCodes()
        {
            XDocument doc = XDocument.Load(filePath);
            return new HashSet<string>(doc.Descendants("CcyNtry")
                      .Select(x => x.Element("Ccy")?.Value)
                      .Where(value => value != null)!);
        }

        /// <summary>
        /// Combines the base directory and the relative path to form a full file path.
        /// </summary>
        /// <param name="baseDirectory">The base directory.</param>
        /// <param name="path">The relative path.</param>
        /// <returns>The combined full file path.</returns>
        private static string pathCombine(string baseDirectory, string path)
        {
            return Path.Combine(baseDirectory, path);
        }
    }
}
