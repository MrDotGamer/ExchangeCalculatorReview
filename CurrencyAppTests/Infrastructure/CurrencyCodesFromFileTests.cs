using CurrencyApp.Infrastructure;

namespace CurrencyAppTests.Infrastructure
{
    [TestFixture]
    public class CurrencyCodesFromFileTests
    {
        private string testFilePath;

        [SetUp]
        public void SetUp()
        {
            testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testCurrencies.xml");
            File.WriteAllText(testFilePath, @"
                <Root>
                    <CcyNtry>
                        <Ccy>USD</Ccy>
                    </CcyNtry>
                    <CcyNtry>
                        <Ccy>EUR</Ccy>
                    </CcyNtry>
                    <CcyNtry>
                        <Ccy>JPY</Ccy>
                    </CcyNtry>
                </Root>");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void GetAvailableCurrencyCodes_ReturnsCorrectCurrencyCodes()
        {
            // Arrange
            var currencyCodesFromFile = new CurrencyCodesFromFile(testFilePath);

            // Act
            HashSet<string> result = currencyCodesFromFile.GetAvailableCurrencyCodes();

            // Assert
            var expected = new HashSet<string> { "USD", "EUR", "JPY" };
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetAvailableCurrencyCodes_WithEmptyFile_ReturnsEmptySet()
        {
            // Arrange
            File.WriteAllText(testFilePath, "<Root></Root>");
            var currencyCodesFromFile = new CurrencyCodesFromFile(testFilePath);

            // Act
            HashSet<string> result = currencyCodesFromFile.GetAvailableCurrencyCodes();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetAvailableCurrencyCodes_WithMissingCcyElements_ReturnsEmptySet()
        {
            // Arrange
            File.WriteAllText(testFilePath, @"
                <Root>
                    <CcyNtry></CcyNtry>
                    <CcyNtry></CcyNtry>
                </Root>");
            var currencyCodesFromFile = new CurrencyCodesFromFile(testFilePath);

            // Act
            HashSet<string> result = currencyCodesFromFile.GetAvailableCurrencyCodes();

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}
