using FizzBuzzApp.Model;

namespace FizzBuzzApp.Tests
{
    public class FizzBuzzServiceTests
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzServiceTests()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Fact]
        public void ProcessValues_MultipleOf3_ReturnsFizz()
        {
            // Arrange
            var values = new[] { "3" };

            // Act
            var results = _fizzBuzzService.ProcessValues(values);

            // Assert
            Assert.Single(results);
            Assert.Equal("Fizz", results[0].Result);
        }

        [Fact]
        public void ProcessValues_MultipleOf5_ReturnsBuzz()
        {
            // Arrange
            var values = new[] { "5" };

            // Act
            var results = _fizzBuzzService.ProcessValues(values);

            // Assert
            Assert.Single(results);
            Assert.Equal("Buzz", results[0].Result);
        }

        [Fact]
        public void ProcessValues_MultipleOf3And5_ReturnsFizzBuzz()
        {
            // Arrange
            var values = new[] { "15" };

            // Act
            var results = _fizzBuzzService.ProcessValues(values);

            // Assert
            Assert.Single(results);
            Assert.Equal("FizzBuzz", results[0].Result);
        }

        [Fact]
        public void ProcessValues_InvalidItem_ReturnsInvalidItem()
        {
            // Arrange
            var values = new[] { "A" };

            // Act
            var results = _fizzBuzzService.ProcessValues(values);

            // Assert
            Assert.Single(results);
            Assert.Equal("Invalid item", results[0].Result);
        }

        [Fact]
        public void ProcessValues_NotMultipleOf3Or5_ReturnsDivisionMessages()
        {
            // Arrange
            var values = new[] { "1" };

            // Act
            var results = _fizzBuzzService.ProcessValues(values);

            // Assert
            Assert.Single(results);
            Assert.Equal("Divided 1 by 3\nDivided 1 by 5", results[0].Result);
        }
    }

}