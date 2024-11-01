namespace CurrencyApp.Application.Exceptions
{
    /// <summary>
    /// Exception thrown when there is an error in parsing currency arguments.
    /// </summary>
    public class ParseCurrencyArgumentsException() : Exception("Currency validation exception occurred. Please check input amount, working formats(123; 123.45; .45; 123.), comma supported too")
    {
    }
}
