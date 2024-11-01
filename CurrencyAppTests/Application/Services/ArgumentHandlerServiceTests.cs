using CurrencyApp.Application.Services;

namespace CurrencyAppTests.Application.Services
{
    [TestFixture]
    public class ArgumentHandlerServiceTests
    {
        private class TestArgumentHandler : ArgumentHandlerService
        {
            public override string[] Handle(string[] args)
            {
                // Custom handling logic for testing
                return base.Handle(args);
            }
        }

        [Test]
        public void SetNext_WithValidHandler_SetsNextHandler()
        {
            // Arrange
            var handler1 = new TestArgumentHandler();
            var handler2 = new TestArgumentHandler();

            // Act
            handler1.SetNext(handler2);

            // Assert
            Assert.That(handler1.SetNext(handler2), Is.SameAs(handler2));
        }

        [Test]
        public void Handle_WithNoNextHandler_ReturnsSameArguments()
        {
            // Arrange
            var handler = new TestArgumentHandler();
            var args = new string[] { "arg1", "arg2", "arg3" };

            // Act
            var result = handler.Handle(args);

            // Assert
            Assert.That(result, Is.EqualTo(args));
        }

        [Test]
        public void Handle_WithNextHandler_CallsNextHandler()
        {
            // Arrange
            var handler1 = new TestArgumentHandler();
            var handler2 = new TestArgumentHandler();
            handler1.SetNext(handler2);
            var args = new string[] { "arg1", "arg2", "arg3" };

            // Act
            var result = handler1.Handle(args);

            // Assert
            Assert.That(result, Is.EqualTo(args));
        }
    }
}
