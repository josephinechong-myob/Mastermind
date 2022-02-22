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
        
        public List<Colour> GetPlayersColourGuess() //return 4 colour enums
        {
            var playerInput = GetPlayerColourInput();

            playerInput = CheckColourListLength(playerInput);
            playerInput = CheckValidColour(playerInput);
            
            return ConvertStringToEnumForColourGuesses(playerInput);
        }

        private string ConvertToTitleCase(string colour)
        {
            colour = colour.Replace(" ", "");
            return colour[0] + colour.Substring(1).ToLower();
        }

        private List<Colour> ConvertStringToEnumForColourGuesses(string playerInput) 
        {
            var colourEnumList = playerInput
                .Split(',').Select(colour => (Colour)Enum.Parse(typeof(Colour), ConvertToTitleCase(colour))).ToList(); 
            return colourEnumList;
        }

        private string CheckColourListLength(string playerInput)
        {
            while (_validator.ThereAreNotFourEntries(playerInput))
            {
                PrintErrorMessage(Constants.ErrorMessageInvalidGuessLength);
                playerInput = GetPlayerColourInput();
            }

            return playerInput;
        }

        private string CheckValidColour(string playerInput)
        {
            while (_validator.AnyColourIsInvalidInInput(playerInput))
            {
                PrintErrorMessage(Constants.ErrorMessageInvalidColour);
                playerInput = GetPlayerColourInput();
            }

            return playerInput;
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
        
        public string GetHints(List<Hint> hints)
        {
            var hintText = "";
            
            for (int i = 0; i < hints.Count; i++)
            {
                hintText += hints[i].ToString();
                
                if (i < hints.Count - 1)
                {
                    hintText += ", ";
                }
            }
            
            return hintText;
        }

        public void PrintHints(string hintText)
        {
            _console.WriteLine($"{hintText}");
        }
    }
}