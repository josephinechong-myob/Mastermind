using System;
using System.Collections.Generic;

namespace mastermind
{
    public class Game
    {
        // randomisation of colors (4) - testing
        private readonly IConsole _console;
        private int _gameCount;
        public List<Colour> MastermindColorsList;
        public Game(IConsole console)
        {
            _console = console;
            _gameCount = 0;
            MastermindColorsList = new List<Colour>();
        }

        public void Run()
        {
            Mastermind();
        }

        private void Mastermind()
        {
            var colours = ColourExtensions.GetColour();
            Random rnd = new Random();
            
            for (var i = 0; i < 4; i++)
            {
                var randomNumber = rnd.Next(colours.Length);
                var randomColour = colours[randomNumber];
                MastermindColorsList.Add(randomColour);
            }

        }
    }
}