using mastermind;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;
using Xunit;

namespace mastermindTest
{
    public class ColoursTest
    {
        [Fact]
        public void Colours_By_Default_Should_Produce_Four_Colours()
        {
            //Arrange
            var expectedMastermindColourListCount = 4;

            //Act
            var randomNumberGenerator = new RandomNumberGenerator();
            var coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            var colours = coloursGenerator.GenerateNew(); //
            var actualMastermindColourListCount = colours.Get().Count;
            
            //Assert
            Assert.Equal(expectedMastermindColourListCount, actualMastermindColourListCount);
        }
    }
}