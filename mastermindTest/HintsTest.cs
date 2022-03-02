using System.Collections.Generic;
using mastermind;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class HintsTest
    {
        [Theory, MemberData(nameof(OneBlackHintData))] //B
        private void A_Black_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.Setup(index => index.NextRandom(It.IsAny<int>())).Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(TwoBlackHintsData))] // B B
        private void Two_Black_Hints_Should_Be_Provided_When_Player_Guesses_Two_Correct_Positioned_Colours(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(ThreeBlackHintsData))] // B B B
        private void Three_Black_Hints_Should_Be_Provided_When_Player_Guesses_Three_Correct_Positioned_Colours(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.Black, Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(FourBlackHintsData))] // B B B B
        private void Four_Black_Hints_Should_Be_Provided_When_Player_Guesses_Four_Correct_Positioned_Colours(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.Black, Hint.Black, Hint.Black};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(OneWhiteHintData))] //W
        private void A_White_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Colour_With_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.Setup(index => index.NextRandom(It.IsAny<int>())).Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(TwoWhiteHintsData))] // W W
        private void Two_White_Hints_Should_Be_Provided_When_Player_Guesses_Two_Correct_Colours_With_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(ThreeWhiteHintsData))] // W W W
        private void Three_White_Hints_Should_Be_Provided_When_Player_Guesses_Three_Correct_Colours_With_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.White, Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(FourWhiteHintsData))] // W W W W
        private void Four_White_Hints_Should_Be_Provided_When_Player_Guesses_Four_Correct_Colours_With_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.White, Hint.White, Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(OneBlackOneWhiteHintData))] //B W
        private void One_White_And_Black_Hint_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_A_Second_Correct_Colour_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(TwoBlackOneWhiteHintData))] //B B W
        private void One_White_And_Two_Black_Hints_Should_Be_Provided_When_Player_Guesses_Two_Correct_Positioned_Colour_And_One_Correct_Colour_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.Black, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(OneBlackTwoWhiteHintData))] //B W W
        private void Two_White_And_One_Black_Hints_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_Two_Correct_Colour_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        [Theory, MemberData(nameof(TwoBlackTwoWhiteHintData))] //B B W W
        private void Two_White_And_Two_Black_Hints_Should_Be_Provided_When_Player_Guesses_Two_Correct_Positioned_Colour_And_Two_Correct_Colour_Improper_Position(List<Colour> mastermindColours, List<Colour> playerColours)
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var expectedHints = new List<Hint> {Hint.Black, Hint.Black, Hint.White, Hint.White};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
        
        // W W W B
        // W W B B
        

        public static IEnumerable<object[]> OneBlackHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Yellow, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Yellow, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Red, Colour.Yellow, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Purple, Colour.Blue, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Orange, Colour.Orange, Colour.Orange, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Purple, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Yellow, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Red, Colour.Red, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Red, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Purple, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Yellow, Colour.Blue, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> TwoBlackHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Yellow, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Red, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Green, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Red, Colour.Red, Colour.Red, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Blue, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Orange, Colour.Red, Colour.Yellow, Colour.Green}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Orange, Colour.Blue, Colour.Green}}
        };
        
        public static IEnumerable<object[]> ThreeBlackHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Yellow, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Orange, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Purple, Colour.Green}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Green, Colour.Blue, Colour.Orange, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Red, Colour.Red, Colour.Green, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Blue, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Orange, Colour.Red, Colour.Blue, Colour.Green}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Orange, Colour.Blue, Colour.Green}}
        };
        
        public static IEnumerable<object[]> FourBlackHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}}
        };
        
        public static IEnumerable<object[]> OneWhiteHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Yellow, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Blue, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Purple, Colour.Yellow, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Yellow}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Orange, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Purple, Colour.Orange, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Yellow, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Red, Colour.Orange, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Purple, Colour.Purple, Colour.Blue}, new List<Colour> {Colour.Blue, Colour.Orange, Colour.Orange, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Red, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Red, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Purple, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Red, Colour.Orange, Colour.Blue, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> TwoWhiteHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Green, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Green, Colour.Yellow, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Green, Colour.Yellow, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Yellow}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Purple, Colour.Red, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Yellow, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Green, Colour.Orange, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Purple, Colour.Purple, Colour.Blue}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Green, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Green}, new List<Colour> {Colour.Red, Colour.Green, Colour.Red, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Red, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Purple, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Red, Colour.Yellow, Colour.Blue, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> ThreeWhiteHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Blue}, new List<Colour> {Colour.Red, Colour.Green, Colour.Blue, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Green, Colour.Yellow, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Green, Colour.Orange, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Yellow}, new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Purple, Colour.Red, Colour.Green, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Yellow, Colour.Green, Colour.Orange}, new List<Colour> {Colour.Yellow, Colour.Green, Colour.Orange, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Purple, Colour.Blue}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Green, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Green, Colour.Purple, Colour.Red}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Red, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Purple, Colour.Purple, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Orange}, new List<Colour> {Colour.Red, Colour.Yellow, Colour.Blue, Colour.Green}}
        };
        
        public static IEnumerable<object[]> FourWhiteHintsData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Orange, Colour.Blue}, new List<Colour> {Colour.Red, Colour.Green, Colour.Blue, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Green, Colour.Yellow, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Purple, Colour.Orange, Colour.Green}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Orange, Colour.Green, Colour.Yellow}, new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Orange, Colour.Green}, new List<Colour> {Colour.Red, Colour.Green, Colour.Green, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Blue, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Yellow, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Yellow, Colour.Orange, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Red, Colour.Orange, Colour.Yellow}, new List<Colour> {Colour.Yellow, Colour.Orange, Colour.Red, Colour.Red}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Orange, Colour.Purple}, new List<Colour> {Colour.Orange, Colour.Purple, Colour.Green, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Red, Colour.Yellow}, new List<Colour> {Colour.Yellow, Colour.Red, Colour.Purple, Colour.Red}}
        };
        
        public static IEnumerable<object[]> OneBlackOneWhiteHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Blue, Colour.Blue, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Purple, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Red, Colour.Yellow, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Purple, Colour.Green, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Blue, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Green, Colour.Orange, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Yellow, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Red, Colour.Red, Colour.Red, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Purple, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Yellow, Colour.Blue, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> TwoBlackOneWhiteHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Blue, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Red, Colour.Purple}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Purple, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Blue, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Blue, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Orange, Colour.Green, Colour.Orange}, new List<Colour> {Colour.Orange, Colour.Green, Colour.Yellow, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Yellow}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Red, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Orange, Colour.Purple, Colour.Blue, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Green, Colour.Blue, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> OneBlackTwoWhiteHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Yellow, Colour.Red, Colour.Green}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Green, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Blue, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Red, Colour.Purple}, new List<Colour> {Colour.Green, Colour.Red, Colour.Orange, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Purple}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Purple, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Yellow, Colour.Purple, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Green, Colour.Green, Colour.Yellow, Colour.Orange}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Blue, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Green, Colour.Red}, new List<Colour> {Colour.Green, Colour.Green, Colour.Red, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Orange, Colour.Blue, Colour.Green, Colour.Yellow}, new List<Colour> {Colour.Orange, Colour.Yellow, Colour.Blue, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Red, Colour.Red, Colour.Blue, Colour.Yellow}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Purple, Colour.Purple, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Purple, Colour.Green, Colour.Blue}}
        };
        
        public static IEnumerable<object[]> TwoBlackTwoWhiteHintData => new List<object[]>
        {
            new object[] {new List<Colour> {Colour.Green, Colour.Yellow, Colour.Red, Colour.Blue}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Blue, Colour.Green, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Orange, Colour.Red, Colour.Purple}, new List<Colour> {Colour.Green, Colour.Red, Colour.Orange, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Blue, Colour.Purple, Colour.Green, Colour.Green}, new List<Colour> {Colour.Blue, Colour.Green, Colour.Purple, Colour.Green}},
            new object[] {new List<Colour> {Colour.Red, Colour.Purple, Colour.Yellow, Colour.Purple}, new List<Colour> {Colour.Red, Colour.Yellow, Colour.Purple, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Green, Colour.Green, Colour.Green}, new List<Colour> {Colour.Green, Colour.Green, Colour.Yellow, Colour.Green}},
            new object[] {new List<Colour> {Colour.Green, Colour.Blue, Colour.Blue, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Red}, new List<Colour> {Colour.Green, Colour.Red, Colour.Red, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Orange, Colour.Blue, Colour.Purple}, new List<Colour> {Colour.Orange, Colour.Yellow, Colour.Blue, Colour.Purple}},
            new object[] {new List<Colour> {Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow}, new List<Colour> {Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue}},
            new object[] {new List<Colour> {Colour.Yellow, Colour.Purple, Colour.Blue, Colour.Green}, new List<Colour> {Colour.Yellow, Colour.Purple, Colour.Green, Colour.Blue}}
        };
        
        [Fact] //happy path = providing a hint
        private void Two_White_And_One_Black_Hints_Should_Be_Provided_When_Player_Guesses_One_Correct_Positioned_Colour_And_Two_Correct_Colours_With_Improper_Position()
        {
            //arrange
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
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
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
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
            var mockRandomiser = new Mock<IRandomNumberGenerator>();
            mockRandomiser.SetupSequence(index => index.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var hintsProvider = new HintProvider(mockRandomiser.Object);
            var mastermindColours = new List<Colour>{Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow};
            var playerColours = new List<Colour>{Colour.Purple, Colour.Purple, Colour.Purple, Colour.Purple};
            var expectedHints = new List<Hint> {};

            //act
            var actualHints = hintsProvider.ProvideHints(playerColours, mastermindColours);

            //assert
            Assert.Equal(expectedHints, actualHints);
        }
        
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