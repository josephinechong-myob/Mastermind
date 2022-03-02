using System;
using System.Collections.Generic;
using System.Linq;
using mastermind.Colours;

namespace mastermind
{
    public class GameDialogue
    {
        private readonly IConsole _console;
        private readonly Validator _validator;

        public GameDialogue(IConsole console)
        {
            _console = console;
            _validator = new Validator();
        }
        
        public List<Colour> GetPlayersColourGuess()
        {
            var playerInput = GetPlayerColourInput();

            playerInput = CheckColourListLength(playerInput);
            playerInput = CheckValidColour(playerInput);
            
            return ConvertStringToEnumForColourGuesses(playerInput);
        }
        
        public void PrintHints(List<Hint> hints)
        {
            if (hints.Count != 0)
            {
                var hintText = GetHints(hints);
                _console.WriteLine($"Hints: {hintText}"); 
            }
            else
            {
                _console.WriteLine("Your guess resulted in no hints");
            }
        }

        public void PrintCorrectColourSolution(List<Colour> mastermindColours)
        {
            var colourString = "";
            for(int i=0; i < mastermindColours.Count; i++)
            {
                colourString += mastermindColours[i].ToString() + (i < mastermindColours.Count - 1 ? ", ": "");
            }
            _console.WriteLine($"{Constants.ErrorMessageExceeding60Attempts} Sorry you have run out of guesses. The correct answer is {colourString}.");
        }

        public void PrintGuessesCount(int guessesCount)
        {
            _console.WriteLine($"Guesses Count is {guessesCount + 1}");
        }

        public bool DoesPlayerWantToReplay()
        {
            _console.WriteLine("Do you want to replay mastermind? Y - Yes, N - No");
            var response = _console.ReadLine();
            while (!_validator.ResponseIsYOrN(response))
            {
                PrintErrorMessage(Constants.ErrorMessageInvalidYesOrNo);
                response = _console.ReadLine();
            }
            return response == "Y";
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
            PrintPlayerInstructions();
            return _console.ReadLine().ToUpper();
        }

        private void PrintPlayerInstructions()
        {
            _console.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)");
        }

        public void PrintAfterPlayerHasWon()
        {
            _console.WriteLine("WON!");
        }
        private void PrintErrorMessage(string errorMessage)
        {
           _console.WriteLine(errorMessage); 
        }
        
        private string GetHints(List<Hint> hints)
        {
            var hintText = "";
            
            for (int i = 0; i < hints.Count; i++)
            {
                hintText += hints[i] + (i < hints.Count - 1 ? ", ": "");
            }
            
            return hintText;
        }
    }
}