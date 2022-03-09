using mastermind;
using mastermind.Game;
using Moq;
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

        public void Guesses_Should_Only_Contain_Four_Valid_Colors(string input, bool expectedOutput)
        {
            //Arrange
            var validator = new GameValidator();

            //Act
            var actualOutput = validator.IsValidColourGuess(input);
            
            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        
        //All colours are capitalised
        [Theory]
        [InlineData("red, blue", false)]
        [InlineData("RED, BLUE, RED, BLUE", true)]
        [InlineData("red, blue, yellow", false)]
        [InlineData("ed", false)]
        [InlineData("YeLloW, yellow, red, blue", true)]
        [InlineData("YELLOW, RED, Blue, yellow", true)]
        
        public void All_Colours_Are_Capitalised(string input, bool expectedOutput)
        {
            //Arrange
            var validator = new GameValidator();

            //Act
            var actualOutput = validator.IsValidColourGuess(input);
            
            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        
        //Valid colour
        [Theory]
        [InlineData("red", true)]
        [InlineData("RED", true)]
        [InlineData("blue", true)]
        [InlineData("green", true)]
        [InlineData("orange", true)]
        [InlineData("purple", true)]
        [InlineData("black", false)]
        [InlineData("White", false)]
        [InlineData("YELLOW", true)]
        
        public void Colours_Are_Valid(string input, bool expectedOutput)
        {
            //Arrange
            var validator = new GameValidator();

            //Act
            var actualOutput = validator.IsValidColour(input);
            
            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}