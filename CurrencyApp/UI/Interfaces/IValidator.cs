namespace CurrencyApp.UI.Interfaces
{
    /// <summary>
    /// Defines a method to validate an array of strings.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates the specified input array of strings.
        /// </summary>
        /// <param name="input">The array of strings to validate.</param>
        /// <returns>An array of validation error messages, or an empty array if validation is successful.</returns>
        string[] Validate(string[] input);
    }
}
