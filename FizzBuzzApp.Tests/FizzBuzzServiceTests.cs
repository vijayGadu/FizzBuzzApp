using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FizzBuzzApp.Controller;
using FizzBuzzApp.Model;

namespace FizzBuzzApp.Tests
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public void ProcessValues_ReturnsOkResult_WithExpectedResults()
        {
            // Arrange
            var mockUtilityService = new Mock<IFizzBuzzUtilityService>();
            var inputValues = new[] { "3", "5", "15", "A", "1" };
            var expectedResults = new List<FizzBuzzResult>
            {
                new FizzBuzzResult { Input = "3", Result = FizzBuzzConstants.Fizz },
                new FizzBuzzResult { Input = "5", Result = FizzBuzzConstants.Buzz },
                new FizzBuzzResult { Input = "15", Result = FizzBuzzConstants.FizzBuzz },
                new FizzBuzzResult { Input = "A", Result = FizzBuzzConstants.InvalidItem },
                new FizzBuzzResult { Input = "1", Result = "Divided 1 by 3\nDivided 1 by 5" }
            };

            mockUtilityService.Setup(service => service.GetFizzBuzzResult(It.Is<int>(n => n == 3))).Returns(FizzBuzzConstants.Fizz);
            mockUtilityService.Setup(service => service.GetFizzBuzzResult(It.Is<int>(n => n == 5))).Returns(FizzBuzzConstants.Buzz);
            mockUtilityService.Setup(service => service.GetFizzBuzzResult(It.Is<int>(n => n == 15))).Returns(FizzBuzzConstants.FizzBuzz);
            mockUtilityService.Setup(service => service.GetFizzBuzzResult(It.Is<int>(n => n == 1))).Returns((string)null);
            mockUtilityService.Setup(service => service.GetDivisionResults(It.Is<int>(n => n == 1))).Returns(new List<string> { "Divided 1 by 3", "Divided 1 by 5" });

            var service = new FizzBuzzService(mockUtilityService.Object);
            var controller = new FizzBuzzController(service);

            // Act
            var result = controller.ProcessValues(inputValues);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<FizzBuzzResult>>(okResult.Value);
            Assert.Equal(expectedResults.Count, returnValue.Count);
            for (int i = 0; i < expectedResults.Count; i++)
            {
                Assert.Equal(expectedResults[i].Input, returnValue[i].Input);
                Assert.Equal(expectedResults[i].Result, returnValue[i].Result);
            }
        }
    }
}
