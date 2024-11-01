namespace CurrencyApp.Application.Exceptions
{
    /// <summary>  
    /// Exception thrown when parameters validation fails.  
    /// </summary>  
    public class ValidationException() : Exception("Parameters validation exception occurred. Example xxx/yyy 20")
    {
    }
}
