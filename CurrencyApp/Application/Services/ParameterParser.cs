using CurrencyApp.UI.Interfaces;
using System.Text.RegularExpressions;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Parses input strings to extract currency codes and amounts.
    /// </summary>
    public class ParameterParser : IParameterParser
    {
        /// <summary>
        /// Parses the input string to extract currency codes, amounts and operator.
        /// </summary>
        /// <param name="input">The input string in the format 'XXX/XXX amount'.</param>
        /// <returns>An array containing the source currency code, target currency code, and amount.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null or empty.</exception>
        public string[] Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cant be empty");
            }
            const string pattern = @"([a-zA-Z]{3})/([a-zA-Z]{3})\s(.+)";
            var match = Regex.Match(input, pattern, RegexOptions.Compiled);
            if (match.Success)
            {
                return [match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value];
            }
            else
            {
                Console.WriteLine("No match found.");
                return [];
            }
        }
    }
}
