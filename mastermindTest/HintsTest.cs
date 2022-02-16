using System.Collections.Generic;
using mastermind;
using Xunit;

namespace mastermindTest
{
    public class HintsTest
    {
        [Fact] //happy path = providing a hint
        private void A_Black_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour()
        {
            //arrange
            var hintsProvider = new HintProvider();
            var playerColours = new List<Colour>{Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue};
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Green, Colour.Green};
            var expectedHints = new List<Hint> {Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);

        }
        
        [Fact] //happy path = providing a hint
        private void One_White_And_Black_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_A_Second_Correct_Colour_Improper_Position()
        {
            //arrange
            var hintsProvider = new HintProvider();
            //var playerColours = new List<Colour>{Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue};
            var playerColours = new List<Colour>{Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Blue};
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Green};
            var expectedHints = new List<Hint> {Hint.Black, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);

        }
        
        [Fact] //happy path = providing a hint
        private void Second_One_White_And_Black_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_A_Second_Correct_Colour_Improper_Position()
        {
            //arrange
            var hintsProvider = new HintProvider();
            var playerColours = new List<Colour>{Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue};
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Green};
            var expectedHints = new List<Hint> {Hint.Black, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);

        }
    }
}