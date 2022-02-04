using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    public class GameDialogue
    {
        private IConsole _console;
        private Validator _validator;

        public GameDialogue(IConsole console)
        {
            _console = console;
            _validator = new Validator();
        }
        
        public List<Colour> GetPlayersColourGuess()
        {
            var playerInput = GetPlayerColourInput();

            CheckColourListLength(playerInput);
            CheckValidColour(playerInput);
            
            return ConvertStringToEnumForColourGuesses(playerInput);
        }

        private List<Colour> ConvertStringToEnumForColourGuesses(string playerInput)
        {
            var colourEnumList = playerInput
                .Split(',').Select(colour => (Colour)Enum.Parse(typeof(Colour), colour)).ToList();
            
            return colourEnumList;
        }

        private void CheckColourListLength(string playerInput)
        {
            while (_validator.ThereAreNotFourEntries(playerInput))
            {
                PrintErrorMessage(Constants.ErrorMessageInvalidGuessLength);
                playerInput = GetPlayerColourInput();
            }
        }

        private void CheckValidColour(string playerInput)
        {
            while (_validator.AnyColourIsInvalidInInput(playerInput))
            {
                PrintErrorMessage(Constants.ErrorMessageInvalidColour);
                playerInput = GetPlayerColourInput();
            }
        }

        private string GetPlayerColourInput()
        {
            Print_Player_Instructions();
            return _console.ReadLine().ToUpper();
        }

        private void Print_Player_Instructions()
        {
            _console.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)");
        }

        private void PrintErrorMessage(string errorMessage)
        {
           _console.WriteLine(errorMessage); 
        }
        
        public string PrintHintArray()
        {
            //obtain hint array from Mastermind
            return " ";
        }
    }
}