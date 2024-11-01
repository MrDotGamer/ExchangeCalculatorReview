using CurrencyApp.Application.Services;

namespace CurrencyAppTests.Application.Services
{
    [TestFixture]
    public class ParameterParserTests
    {
        private ParameterParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new ParameterParser();
        }

        [Test]
        public void Parse_ValidInput_ReturnsParsedParameters()
        {
            // Arrange
            var input = "USD/EUR 100";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.That(result, Is.EqualTo(new[] { "USD", "EUR", "100" }));
        }

        [Test]
        public void Parse_InvalidInput_ReturnsEmptyArray()
        {
            // Arrange
            var input = "Invalid Input";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_EmptyInput_ReturnsEmptyArray()
        {
            // Arrange
            var input = "";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_NullInput_ReturnException()
        {
            // Arrange
            string? input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _parser.Parse(input!));
        }
    }
}
