namespace CurrencyApp.UI.Interfaces
{
    /// <summary>
    /// Defines a method to parse a given input string into an array of strings.
    /// </summary>
    public interface IParameterParser
    {
        /// <summary>
        /// Parses the specified input string into an array of strings.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <returns>An array of strings parsed from the input.</returns>
        string[] Parse(string input);
    }
}
