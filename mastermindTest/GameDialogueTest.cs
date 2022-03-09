using System.Collections.Generic;
using mastermind;
using mastermind.Colours;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class GameDialogueTest
    {
        [Fact]
        private void Should_Print_Hint_List_To_Console()
        {
            //arrange
            var hints = new List<Hint> {Hint.Black, Hint.White};
            var expectedHintText = "Hints: Black, White";
            var mockConsole = new Mock<IConsole>();
            var gameDialogue = new GameDialogue(mockConsole.Object);

            //act
            gameDialogue.PrintHints(hints);

            //assert
            mockConsole.Verify(expression => expression.WriteLine(expectedHintText),Times.Once);
        }
        
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
            //convert enum to a list dynamically 
            
            //assert
            Assert.Equal(expectedGuessLength, actualColours.Count);
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Blue, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType()); //checks it is a colour but not as good as checking it is the colour we expect
        }
        
        [Fact]
        private void Should_Return_Error_If_Guesses_Does_Not_Contain_Four_Colours()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(guess => guess.ReadLine())
                .Returns("Red, Red, Blue, Blue, Yellow")
                .Returns("Red, Red, Blue, Yellow");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedGuessLength = 4;

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();
            //convert enum to a list dynamically 
            
            //assert
            Assert.Equal(expectedGuessLength, actualColours.Count);
            mockConsole.Verify(expression => expression.WriteLine("Error: you must pass 4 colours!"),Times.Once);
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Yellow, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType());
        }
        
        [Fact]
        private void Should_Return_Error_If_Guesses_Does_Not_Contain_Valid_Colour()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(guess => guess.ReadLine())
                .Returns("Red, Red, Peach, Yellow")
                .Returns("Red, Red, Blue, Yellow");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedGuessLength = 4;

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();

            //assert
            Assert.Equal(expectedGuessLength, actualColours.Count);
            mockConsole.Verify(expression => expression.WriteLine("Error: you have given an invalid colour!"),Times.Once);
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Yellow, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType());
        }
        
        [Fact]
        private void Should_Return_Colour_Enum_List_Type()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(guess => guess.ReadLine())
                .Returns("Red, Red, Blue, Yellow");
            var gameDialogue = new GameDialogue(mockConsole.Object);

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();
            //convert enum to a list dynamically 
            
            //assert
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Yellow, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType());
        }
        
        [Fact]
        private void User_Input_Does_Not_Require_Specific_Case_Input_Styling()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(guess => guess.ReadLine()).Returns("RED, blue, GrEeN, YELlow");
            var gameDialogue = new GameDialogue(mockConsole.Object);

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();

            //assert
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Blue, actualColours[1]);
            Assert.Equal(Colour.Green, actualColours[2]);
            Assert.Equal(Colour.Yellow, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType());
        }
        
        [Fact]
        private void Should_Print_Player_Instructions()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(guess => guess.ReadLine())
                .Returns("Red, Red, Peach, Yellow")
                .Returns("Red, Red, Blue, Yellow");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedGuessLength = 4;

            //act
            var actualColours = gameDialogue.GetPlayersColourGuess();

            //assert
            Assert.Equal(expectedGuessLength, actualColours.Count);
            mockConsole.Verify(expression => expression.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)"),Times.Exactly(2));
            Assert.Equal(Colour.Red, actualColours[0]);
            Assert.Equal(Colour.Red, actualColours[1]);
            Assert.Equal(Colour.Blue, actualColours[2]);
            Assert.Equal(Colour.Yellow, actualColours[3]);
            Assert.Equal(typeof(Colour), actualColours[0].GetType());
        }

        [Fact]
        private void Should_Print_Hints_When_There_Are_Hints()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var hints = new List<Hint> {Hint.Black, Hint.White};
            
            //act
            gameDialogue.PrintHints(hints);

            //assert
            mockConsole.Verify(expression => expression.WriteLine("Hints: Black, White"),Times.Once);
        }
        
        [Fact]
        private void Should_Print_No_Hints_Available_When_There_Are_No_Hints()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var hints = new List<Hint> {};
            
            //act
            gameDialogue.PrintHints(hints);

            //assert
            mockConsole.Verify(expression => expression.WriteLine("Your guess resulted in no hints"),Times.Once);  
        }

        [Fact]
        private void Should_Return_False_When_Player_Enters_No_To_If_They_Want_To_Replay_Game()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(n => n.ReadLine()).Returns("N");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedPlayerResponse = false;

            //act
            var actualPlayerResponse = gameDialogue.DoesPlayerWantToReplay();
            
            //assert
            Assert.Equal(expectedPlayerResponse, actualPlayerResponse);
            mockConsole.Verify(expression => expression.WriteLine("Do you want to replay mastermind? Y - Yes, N - No"));
        }
        
        [Fact]
        private void Should_Return_True_When_Player_Enters_Yes_To_If_They_Want_To_Replay_Game()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(n => n.ReadLine()).Returns("Y");
            var gameDialogue = new GameDialogue(mockConsole.Object);
            var expectedPlayerResponse = true;

            //act
            var actualPlayerResponse = gameDialogue.DoesPlayerWantToReplay();
            
            //assert
            Assert.Equal(expectedPlayerResponse, actualPlayerResponse);
            mockConsole.Verify(expression => expression.WriteLine("Do you want to replay mastermind? Y - Yes, N - No"));
        }
        
        [Fact]
        private void Should_Return_Error_When_Player_Enters_Invalid_Response_To_If_They_Want_To_Replay_Game()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(n => n.ReadLine())
                .Returns("9")
                .Returns("N");
            var gameDialogue = new GameDialogue(mockConsole.Object);

            //act
            gameDialogue.DoesPlayerWantToReplay();
            
            //assert
            mockConsole.Verify(expression => expression.WriteLine("Error: you have given an invalid entry. Please enter 'Y' - Yes or 'N' - No"));
        }
    }
}