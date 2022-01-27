using System;
using System.Collections.Generic;
using mastermind;
using Moq;
using Xunit;

namespace mastermindTest
{
    public class GameTest
    {
        [Fact]
        public void Mastermind_Should_Produce_Four_Colours()
        {
            //Arrange
            var mockConsole = new Mock<IConsole>();
            var game = new Game(mockConsole.Object);
            var expectedMastermindColourListCount = 4;
            
            //Act
            game.Run();
            var actualMastermindColourListCount = game.MastermindColorsList.Count;
            
            //Assert
            Assert.Equal(expectedMastermindColourListCount, actualMastermindColourListCount);
        }
    }
}