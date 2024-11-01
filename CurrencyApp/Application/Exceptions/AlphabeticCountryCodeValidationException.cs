namespace CurrencyApp.Application.Exceptions
{
    /// <summary>
    /// Exception thrown when an invalid alphabetic country code is encountered.
    /// </summary>
    public class AlphabeticCountryCodeValidationException() : Exception("Alphabetic country code validation exception occurred. Please check input country codes, example: xxx/yyy")
    {
    }
}
