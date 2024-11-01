using CurrencyApp.Application.Exceptions;
using CurrencyApp.Application.ValidationHandlers;

namespace CurrencyAppTests.Application.Handlers
{
    [TestFixture]
    public class ArgumentsValidationHandlerTests
    {
        [Test]
        public void Handle_WithValidArguments_ReturnsArguments()
        {
            // Arrange
            var handler = new ArgumentsValidationHandler();
            var args = new string[] { "arg1", "arg2", "arg3" };

            // Act
            var result = handler.Handle(args);

            // Assert
            Assert.That(result, Is.EqualTo(args));
        }

        [Test]
        public void Handle_WithInvalidArguments_ThrowsValidationException()
        {
            // Arrange
            var handler = new ArgumentsValidationHandler();
            var args = new string[] { "arg1", "arg2" };

            // Act & Assert
            Assert.Throws<ValidationException>(() => handler.Handle(args));
        }
    }
}
