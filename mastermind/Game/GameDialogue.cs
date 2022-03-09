using System;
using System.Collections.Generic;
using System.Linq;
using mastermind.Abstract;
using mastermind.Colours;

namespace mastermind.Game
{
    public class GameDialogue
    {
        private readonly IGameConsole _gameConsole;
        private readonly GameValidator _gameValidator;

        public GameDialogue(IGameConsole gameConsole)
        {
            _gameConsole = gameConsole;
            _gameValidator = new GameValidator();
        }
        
        public List<Colour> GetPlayersColourGuess()
        {
            var playerInput = GetPlayerColourInput();

            playerInput = CheckColourListLength(playerInput);
            playerInput = CheckValidColour(playerInput);
            
            return ConvertStringToEnumForColourGuesses(playerInput);
        }
        
        public void PrintHints(List<Hint.Hint> hints)
        {
            if (hints.Count != 0)
            {
                var hintText = GetHints(hints);
                _gameConsole.WriteLine($"Hints: {hintText}"); 
            }
            else
            {
                _gameConsole.WriteLine("Your guess resulted in no hints");
            }
        }

        public void PrintCorrectColourSolution(List<Colour> mastermindColours)
        {
            var colourString = "";
            for(int i=0; i < mastermindColours.Count; i++)
            {
                colourString += mastermindColours[i].ToString() + (i < mastermindColours.Count - 1 ? ", ": "");
            }
            _gameConsole.WriteLine($"{GameConstants.ErrorMessageExceeding60Attempts} Sorry you have run out of guesses. The correct answer is {colourString}.");
        }

        public void PrintGuessesCount(int guessesCount)
        {
            _gameConsole.WriteLine($"Guesses Count is {guessesCount}");
        }

        public bool DoesPlayerWantToReplay()
        {
            _gameConsole.WriteLine("Do you want to replay mastermind? Y - Yes, N - No");
            var response = _gameConsole.ReadLine();
            while (!_gameValidator.ResponseIsYOrN(response))
            {
                PrintErrorMessage(GameConstants.ErrorMessageInvalidYesOrNo);
                response = _gameConsole.ReadLine();
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
            while (_gameValidator.ThereAreNotFourEntries(playerInput))
            {
                PrintErrorMessage(GameConstants.ErrorMessageInvalidGuessLength);
                playerInput = GetPlayerColourInput();
            }

            return playerInput;
        }

        private string CheckValidColour(string playerInput)
        {
            while (_gameValidator.AnyColourIsInvalidInInput(playerInput))
            {
                PrintErrorMessage(GameConstants.ErrorMessageInvalidColour);
                playerInput = GetPlayerColourInput();
            }

            return playerInput;
        }

        private string GetPlayerColourInput()
        {
            PrintPlayerInstructions();
            return _gameConsole.ReadLine().ToUpper();
        }

        private void PrintPlayerInstructions()
        {
            _gameConsole.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)");
        }

        public void PrintAfterPlayerHasWon()
        {
            _gameConsole.WriteLine("WON!");
        }
        private void PrintErrorMessage(string errorMessage)
        {
           _gameConsole.WriteLine(errorMessage); 
        }
        
        private string GetHints(List<Hint.Hint> hints)
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