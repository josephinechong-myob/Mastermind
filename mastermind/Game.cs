using System;
using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Game
    {
        private int _gameCount;
        private Colours _colours;
        private IRandomNumberGenerator _randomNumberGenerator;
        private GameDialogue _gameDialogue;
        private Mastermind _mastermind;
        
        //game input console and that could store all the input and output you need for the game and a game input validator 
        //public colours MastermindsColours
        //public mastermind master - replace line 11
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _gameCount = 0;
            _colours = new Colours(new List<Colour>());//to do refactor for updated list
            _randomNumberGenerator = randomNumberGenerator;
            _gameDialogue = new GameDialogue(console);
            _mastermind = new Mastermind(_randomNumberGenerator);
        }

        public void Run()
        {
            //mastermind - computer guess - already generated
            var player = new Player();
            var playersColourGuess = _gameDialogue.GetPlayersColourGuess();
            _mastermind.CheckPlayerColoursGuess(playersColourGuess);
            //Check players guess - 
            //return hint array
            //Print out hint array 
            //if successful reset game
        }

        public void CheckPlayersGuesses()
        {
            
        }
        
    }
}