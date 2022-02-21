using System.Collections.Generic;
using mastermind;
using mastermind.RandomNumberGenerator;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class HintsTest
    {
        /*[Fact] //happy path = providing a hint
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
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Green};
            var playerColours = new List<Colour>{Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue};
            var expectedHints = new List<Hint> {Hint.Black, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Fact] //happy path = providing a hint
        private void Two_White_And_One_Black_Hints_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_Two_Correct_Colours_With_Improper_Position()
        {
            //arrange
            var hintsProvider = new HintProvider();
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Green}; // G B G
            var playerColours = new List<Colour>{Colour.Blue, Colour.Red, Colour.Green, Colour.Blue}; // B G B
            var expectedHints = new List<Hint> {Hint.Black, Hint.White, Hint.White}; // W B W

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Fact] //happy path = providing a hint
        private void Three_White_Should_Be_Provided_When_Player_Guesses_Three_Correct_Colours_With_Improper_Position()
        {
            //arrange
            var hintsProvider = new HintProvider();
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow};
            var playerColours = new List<Colour>{Colour.Yellow, Colour.Yellow, Colour.Green, Colour.Blue};
            var expectedHints = new List<Hint> {Hint.White, Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Fact] //happy path = providing a hint
        private void No_Hints_Should_Be_Provided_When_Player_Provides_All_Wrong_Guesses()
        {
            //arrange
            var hintsProvider = new HintProvider();
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow};
            var playerColours = new List<Colour>{Colour.Purple, Colour.Purple, Colour.Purple, Colour.Purple};
            var expectedHints = new List<Hint> {};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }*/
        
        [Fact] //hints should be in random order - mock the random
        private void Hints_Provided_Should_Be_Provided_In_Random_Order()
        {
            //arrange
            
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(2)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow};
            var playerColours = new List<Colour>{Colour.Green, Colour.Purple, Colour.Red, Colour.Yellow};
            var expectedHints = new List<Hint> {Hint.White, Hint.Black, Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
    }
}