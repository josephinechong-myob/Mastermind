using mastermind;
using mastermind.RandomNumberGenerator;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class GameTest
    {
        [Fact]
        private void Should_Reset_Game_After_Sixty_Tries_Or_Player_Has_Won()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            //playerinput
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Green, Red, Red, Red");
            //mock mastermind colours
            mockRandomNumberGenerator.SetupSequence(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(2)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(console => console.WriteLine("You have won!"),Times.Once());
        }
        
        [Fact]
        private void Should_Print_A_Hint_If_Game_Is_Under_Sixty_Tries_And_Player_Has_Not_Won()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            //playerinput
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Purple, Red, Red, Red")
                .Returns("Red, Red, Red, Red");
            //mock mastermind colours
            mockRandomNumberGenerator.SetupSequence(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(console => console.WriteLine("Hints: Black, Black, Black"),Times.Once());
        }
        
        [Fact]
        private void Should_Increment_Game_Count_By_Two_When_Player_Makes_Two_Guesses()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            //playerinput
            mockConsole.SetupSequence(playerInput => playerInput.ReadLine())
                .Returns("Purple, Red, Red, Red")
                .Returns("Red, Red, Red, Red");
            //mock mastermind colours
            mockRandomNumberGenerator.SetupSequence(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(0);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
            var expectedGameCount = 2;
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(n => n.ReadLine(), Times.Exactly(2));
        }
        
        [Fact]
        private void Should_Print_Solution_When_Player_Surpasses_Sixty_Tries()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            //playerinput
            mockConsole.Setup(playerInput => playerInput.ReadLine())
                .Returns("Purple, Red, Red, Red");
            //mock mastermind colours
            mockRandomNumberGenerator.Setup(mastermind => mastermind.NextRandom(It.IsAny<int>()))
                .Returns(0);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
            var expectedGameCount = 60;
            
            //act
            game.Run();

            //assert
            mockConsole.Verify(n => n.ReadLine(),Times.Exactly(expectedGameCount));
            mockConsole.Verify(n => n.WriteLine("Sorry you have run out of guesses. The correct answer is Red, Red, Red, Red."),Times.Once);
        }
        
        //unhappy path and show a hint 
    }
}