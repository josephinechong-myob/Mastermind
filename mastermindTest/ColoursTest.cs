using mastermind;
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
            var colours = Colours.GenerateNew();
            var actualMastermindColourListCount = colours.ColoursList.Count;
            
            //Assert
            Assert.Equal(expectedMastermindColourListCount, actualMastermindColourListCount);
        }
    }
}