namespace CurrencyApp.Infrastructure.Services
{
    public interface ICurrencyCodesRepo
    {
        HashSet<string> GetAvailableCurrencyCodes();
    }
}
