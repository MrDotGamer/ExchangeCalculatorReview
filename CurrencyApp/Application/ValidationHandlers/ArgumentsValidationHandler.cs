using CurrencyApp.Application.Exceptions;
using CurrencyApp.Application.Services;

namespace CurrencyApp.Application.ValidationHandlers
{
    /// <summary>  
    /// Handles the validation of arguments passed to the application.  
    /// </summary>  
    public class ArgumentsValidationHandler() : ArgumentHandlerService
    {
        /// <summary>  
        /// Validates the provided arguments.  
        /// </summary>  
        /// <param name="args">The arguments to validate.</param>  
        /// <returns>The validated arguments.</returns>  
        /// <exception cref="ValidationException">Thrown when the number of arguments is not equal to 3.</exception>  
        public override string[] Handle(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ValidationException();
            }
            return base.Handle(args);
        }
    }
}