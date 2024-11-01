using CurrencyApp.Application.Services;
using CurrencyApp.Infrastructure.Services;
using Moq;

namespace CurrencyAppTests.Application.Services
{
    [TestFixture]
    public class AvailableCurrencyCodeCacheTests
    {
        private Mock<ICurrencyCodesRepo> _mockCurrencyCodesRepo;
        private AvailableCurrencyCodeCache? _cache;

        [SetUp]
        public void SetUp()
        {
            _mockCurrencyCodesRepo = new Mock<ICurrencyCodesRepo>();
            _mockCurrencyCodesRepo.Setup(repo => repo.GetAvailableCurrencyCodes())
                                  .Returns(["USD", "EUR", "GBP"]);

            // Use reflection to set the private instance field to null before each test
            var instanceField = typeof(AvailableCurrencyCodeCache)
                .GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (instanceField != null)
            {
                instanceField.SetValue(null, null);
            }

            // Use reflection to set the private _currencyCodesRepo field
            var constructor = typeof(AvailableCurrencyCodeCache)
                .GetConstructor(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, new System.Type[0], null);
            if (constructor != null)
            {
                _cache = (AvailableCurrencyCodeCache)constructor.Invoke(null);
            }

            var repoField = typeof(AvailableCurrencyCodeCache)
                .GetField("_currencyCodesRepo", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            repoField?.SetValue(_cache, _mockCurrencyCodesRepo);
        }

        [Test]
        public void Instance_WhenCalled_ReturnsSingletonInstance()
        {
            // Act
            var instance1 = AvailableCurrencyCodeCache.Instance;
            var instance2 = AvailableCurrencyCodeCache.Instance;

            // Assert
            Assert.That(instance1, Is.SameAs(instance2));
        }

        [Test]
        public void GetAvailableCurrencyCodes_WhenCalled_ReturnsCurrencyCodes()
        {
            // Act
            var result = _cache!.GetAvailableCurrencyCodes();

            // Assert
            Assert.That(result, Is.EquivalentTo(new HashSet<string> { "USD", "EUR", "GBP" }));
        }
    }
}
