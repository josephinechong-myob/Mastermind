using mastermind;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class GameDialogueTest
    {
        [Fact]
        private void Should_Return_String_Of_Four_Colour_Guesses()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(guess => guess.ReadLine()).Returns("Red, Red, Blue, Blue");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedGuessLength = 4;

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();
            
            //assert
            Assert.Equal(expectedGuessLength, actualColours.Count);
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Blue, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType()); //checks it is a colour but not as good as checking it is the colour we expect
            
        }
        
        
    }
}