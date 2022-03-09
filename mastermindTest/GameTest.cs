using mastermind;
using mastermind.Abstract;
using mastermind.Game;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class GameTest
    {
        [Fact]
        private void Should_Print_Player_Has_Won_If_Player_Guesses_Correctly()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Red, Red, Red, Red")
                .Returns("N");
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new MastermindGame(mockConsole.Object, mockRandomNumberGenerator.Object);

            //act
            game.Run();

            //assert
            mockConsole.Verify(console => console.WriteLine("WON!"),Times.Once());
            mockConsole.Verify(n => n.WriteLine("Do you want to replay mastermind? Y - Yes, N - No"),Times.Exactly(1));
        }
        
        [Fact]
        private void Should_Print_A_Hint_If_Game_Is_Under_Sixty_Tries_And_Player_Has_Not_Won()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Purple, Red, Red, Red")
                .Returns("Red, Red, Red, Red")
                .Returns("N");
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new MastermindGame(mockConsole.Object, mockRandomNumberGenerator.Object);
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(console => console.WriteLine("Hints: Black, Black, Black"),Times.Once());
        }
        
        [Fact]
        private void Should_Print_Solution_When_Player_Surpasses_Sixty_Tries()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("Purple, Red, Red, Red")
                .Returns("N");
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new MastermindGame(mockConsole.Object, mockRandomNumberGenerator.Object);
            var expectedGuessCount = 60;
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(n => n.WriteLine("Hints: Black, Black, Black"), Times.Exactly(expectedGuessCount));
            mockConsole.Verify(n => n.WriteLine("Error: you have had more than 60 tries! Sorry you have run out of guesses. The correct answer is Red, Red, Red, Red."),Times.Once);
        }
        
        [Fact]
        private void Should_Reset_Game_If_Player_Responds_Yes_To_Replay_Game()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Red, Red, Red, Red")
                .Returns("Y")
                .Returns("Red, Red, Red, Red")
                .Returns("N");
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new MastermindGame(mockConsole.Object, mockRandomNumberGenerator.Object);

            //act
            game.Run();

            //assert
            mockConsole.Verify(n => n.WriteLine("Do you want to replay mastermind? Y - Yes, N - No"),Times.Exactly(2));
            mockConsole.Verify(n => n.ReadLine(),Times.Exactly(4));
        }
        
        [Fact]
        private void Should_End_Game_If_Player_Responds_No_To_Replay_Game()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Red, Red, Red, Red")
                .Returns("N");
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new MastermindGame(mockConsole.Object, mockRandomNumberGenerator.Object);

            //act
            game.Run();

            //assert
            mockConsole.Verify(n => n.WriteLine("Do you want to replay mastermind? Y - Yes, N - No"),Times.Exactly(1));
        }
    }
}