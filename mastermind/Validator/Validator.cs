using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace mastermind.Validator
{
    public class Validator
    {
        public bool IsValidColourGuess(string playerResponse)// empty string, non-letters, no comma, check that there are 3 commas (4 colours), are the colour valid colours - regex 
        {
            playerResponse = playerResponse.ToUpper(); //use () not [] for alternative colour options
            var pattern = "(RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW)";
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerResponse != String.Empty;
            var patternIsMatch = validPattern.IsMatch(playerResponse);
            return stringIsNotEmpty && patternIsMatch;
        }
        
        public bool IsValidColour(string playerResponse)
        {
            playerResponse = playerResponse.ToUpper();
            var pattern = "(RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW)";
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerResponse != String.Empty;
            var patternIsMatch = validPattern.IsMatch(playerResponse);
            return stringIsNotEmpty && patternIsMatch;
        }

        public bool ThereAreNotFourEntries(string playerInput)
        {
            return playerInput.Count(character => character == ',') != 3;
        }

        public bool AnyColourIsInvalidInInput(string playerInput)
        {
            return playerInput.Split(',').Any(colour => !IsValidColour(colour));
        }

        public bool ResponseIsYOrN(string playerInput)
        {
            playerInput = playerInput.ToUpper();
            var pattern = "(N|Y)";
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerInput != String.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch;
        }
    }
}