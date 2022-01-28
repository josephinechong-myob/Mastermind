using System.Collections.Generic;

namespace mastermind
{
    public class Player
    {
        private readonly IConsole _console;
        public List<Colour> PlayersColoursGuess;
        
        public Player(IConsole console)
        {
            _console = console;
            PlayersColoursGuess = new List<Colour>();
        }

        /*public static void GetPlayersColourGuess()
        {
            _console.WriteLine("What is your name?");
            var name = _console.ReadLine();
            _console.WriteLine($"{name} the colours available are red, blue, green, orange, purple and yellow. Please enter your guess of four colours (i.e. RED, RED, GREEN, BLUE)");
            var playersColoursString = _console.ReadLine();
            string[] playerInputSplitted = playersColoursString.Split(',');
            for (var i = 0; i < playerInputSplitted.Length; i++)
            {
                //convert string to colour enum
                PlayersColoursGuess.Add(playerInputSplitted[i]);
            }
        }*/
    }
}