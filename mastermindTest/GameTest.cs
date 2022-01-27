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
        public void Mastermind_Should_Produce_Four_Random_Colours()
        {
            //Arrange
            var mockConsole = new Mock<IConsole>();
            var game = new Game(mockConsole.Object);
            var mastermindColourList = new List<Colours>();
            var expectedMastermindColourListCount = 4;
            
            //Act
            game.Run();
            var actualMastermindColourListCount = mastermindColourList.Count;
            
            //Assert
            //mockConsole.Verify(console => console.WriteLine(()));
            Assert.Equal(expectedMastermindColourListCount, actualMastermindColourListCount);
        }
    }
}