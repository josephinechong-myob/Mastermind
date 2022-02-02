using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    public class GameDialogue
    {
        private IConsole _console;

        public GameDialogue(IConsole console)
        {
            _console = console;
        }
        
        public List<Colour> GetPlayersColourGuess()
        {
            _console.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)");
            var stringResponse = _console.ReadLine();
            //validator.validate(stringResponse);

            var splitStringResponse = stringResponse.Split((',')).ToList();
            var playersColoursGuess = new List<Colour>();

            foreach (var colour in splitStringResponse)
            {
                Colour guessColour;
                Enum.TryParse(colour, out guessColour);
                playersColoursGuess.Add(guessColour);
            }
            
            return playersColoursGuess;
        }
        

        public string PrintHintArray()
        {
            //obtain hint array from Mastermind
            return " ";
        }
    }
}