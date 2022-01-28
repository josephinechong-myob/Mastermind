using System;
using System.Collections.Generic;

namespace mastermind
{
    public class Game
    {
        private readonly IConsole _console;
        private int _gameCount;
        private Colours _colours;
        
        //public colours MastermindsColours
        //public mastermind master - replace line 11
        public Game(IConsole console)
        {
            _console = console;
            _gameCount = 0;
            _colours = new Colours(new List<Colour>());//to do refactor for updated list

        }

        public void Run()
        {
            //Get computer == mastermind 4 colors
            Mastermind();
            
            //Get player guess
            var player = new Player(_console);
           // Player.GetPlayersColourGuess();
            
            //validate player input
            //Check players guess
            //return hint array
            //if successful reset game
        }

        private void Mastermind()
        {
            Colours.GenerateNew();
            
            //MastermindsColours = new Colours();
        }
    }
}