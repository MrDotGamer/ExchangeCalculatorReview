// See https://aka.ms/new-console-template for more information
using CurrencyApp.Application.Services;
using CurrencyApp.Core.Models;
using CurrencyApp.UI.Extensions;
using CurrencyApp.UI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ExchangeServiceProviderExtension.BuildServiceProvider();

var isStopped = false;
while (!isStopped)
{
    Console.WriteLine("Please enter the exchange parameters in the following format: USD/EUR 100");
    var input = Console.ReadLine();
    if (input == null || input.Equals(string.Empty))
    {
        continue;
    }
    if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
    {
        isStopped = true;
        continue;
    }
    try
    {
        var parser = new ParameterParser();

        var parsedInput = parser.Parse(input!);

        var validator = new ExchangeParameterValidator();

        var validatedArguments = validator.Validate(parsedInput);

        var calculatorFactory = new CalclatorFactory();

        var calculator = calculatorFactory.CreateExchangeCalculator();

        var availableRates = serviceProvider.GetService<IExchangeRateService>();

        calculator.Calculate(availableRates!.GetRates(), ExchangeToken.Create(validatedArguments));

        Console.WriteLine(calculator.CalculationResult);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

