using CurrencyApp.Application.ValidationHandlers;
using CurrencyApp.UI.Interfaces;

namespace CurrencyApp.Application.Services
{
    /// <summary>
    /// Validates exchange parameters using the specified validation handler.
    /// </summary>
    public class ExchangeParameterValidator : IValidator
    {
        private readonly ArgumentsValidationHandler argumentsValidation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeParameterValidator"/> class.
        /// </summary>
        public ExchangeParameterValidator()
        {
            argumentsValidation = new ArgumentsValidationHandler();
        }

        /// <summary>
        /// Validates the input parameters.
        /// </summary>
        /// <param name="input">The input parameters to validate.</param>
        /// <returns>An array of validation error messages, if any.</returns>
        public string[] Validate(string[] input)
        {
            return argumentsValidation.Handle(input);
        }
    }
}
