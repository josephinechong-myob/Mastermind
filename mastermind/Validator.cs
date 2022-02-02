using System;
using System.Text.RegularExpressions;

namespace mastermind
{
    public class Validator
    {
        
        public Validator()
        {
            
        }

        public bool IsValidColourGuess(string playerResponse)// empty string, non-letters, no comma, check that there are 3 commas (4 colours), are the colour valid colours - regex 
        {
            playerResponse = playerResponse.ToUpper(); //use () not [] for alternative colour options
            var pattern = "(RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW), (RED|BLUE|GREEN|ORANGE|PURPLE|YELLOW)";
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerResponse != String.Empty;
            var patternIsMatch = validPattern.IsMatch(playerResponse);
            return stringIsNotEmpty && patternIsMatch;
            //while (playerResponse !== validPattern)
            {
                //Ask them to enter a valid response, TryParse
            }
        }
        //Passing an invalid colour will fail the test with the error "Error: you have given an invalid colour!"
        
        //Passing an invalid array length will fail the test with the error "Error: you must pass 4 colours!"
        
        //Guessing more than 60 times will fail the test with the error "Error: you have had more than 60 tries!"
        
        //All colours are capitalised
    }
}