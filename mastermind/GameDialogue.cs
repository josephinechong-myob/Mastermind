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
            
            Player_Instructions();
            var stringResponse = _console.ReadLine().ToUpper();
            var colourStringList = stringResponse.Split((',')).ToList();

            while (colourStringList.Count != 4)
            {
                _console.WriteLine(Constants.Error_Message_Invalid_Guess_Length);
                Player_Instructions();
                stringResponse = _console.ReadLine().ToUpper();
                colourStringList = stringResponse.Split((',')).ToList();
            }

            foreach (var colour in colourStringList)
            {
                while (!_validator.IsValidColour(colour))
                {
                    _console.WriteLine(Constants.Error_Message_Invalid_Colour);
                    Player_Instructions();
                    stringResponse = _console.ReadLine().ToUpper();
                    colourStringList = stringResponse.Split((',')).ToList();
                }
            }
            
            var colourEnumList = new List<Colour>();

            foreach (var colour in colourStringList)
            {
                colourEnumList.Add((Colour)Enum.Parse(typeof(Colour), colour));
            }
            
            return colourEnumList;
        }
        
        public void Player_Instructions()
        {
            _console.WriteLine("Please enter your guess of four colours for mastermind separated by comma (i.e. Red, Orange, Yellow, Orange)");
        }
        
        public string PrintHintArray()
        {
            //obtain hint array from Mastermind
            return " ";
        }
    }
}