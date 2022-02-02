using mastermind;
using Xunit;

namespace mastermindTest
{
    public class ValidatorTest
    {
        
        [Theory]
        [InlineData("red, blue", false)]
        [InlineData("RED, BLUE, RED, BLUE", true)]
        [InlineData("red, blue, yellow", false)]
        [InlineData("ed", false)]
        [InlineData("YeLloW, yellow, red, blue", true)]
        [InlineData("YELLOW, RED, Blue, yellow", true)]
        
        public void Guesses_Should_Only_Contain_Four_Valid_Colors(string input, bool expectedOutput)
        {
            //Arrange
            var validator = new Validator();

            //Act
            var actualOutput = validator.IsValidColourGuess(input);
            
            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}