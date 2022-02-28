using System;
using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Game
    {
        public int GameCount { get; private set; }
        private Colours _colours;
        private IRandomNumberGenerator _randomNumberGenerator;
        private GameDialogue _gameDialogue;
        private Mastermind _mastermind;
        
        //game input console and that could store all the input and output you need for the game and a game input validator 
        //public colours MastermindsColours
        //public mastermind master - replace line 11
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            GameCount = 1;
            _colours = new Colours(new List<Colour>());//to do refactor for updated list
            _randomNumberGenerator = randomNumberGenerator;
            _gameDialogue = new GameDialogue(console);
            _mastermind = new Mastermind(_randomNumberGenerator);
        }

        public void Run()
        {
            var hints = new List<Hint>();
            while (GameCount <= 60 && !PlayerHasWon(hints))
            {
                var player = new Player();
            
                var playersColourGuess = 
                    _gameDialogue.GetPlayersColourGuess();
            
                hints = _mastermind.CheckPlayerColoursGuess(playersColourGuess);
            
                _gameDialogue.PrintHints(hints);
                _gameDialogue.PrintGameCount(GameCount);
                
                GameCount++;
            }

            if (PlayerHasWon(hints))
            {
                _gameDialogue.PrintAfterPlayerHasWon();
            }
            else
            {
                _gameDialogue.PrintCorrectColourSolution(_mastermind.Colours.Get());
            }
            
            //ask to reset game
            
            
            
            //if successful reset game
            // after 60 tries tell them they are unsuccessful (reveal solution) ask about reset game
            
            //game evaluator class?
        }

        private bool PlayerHasWon(List<Hint> hints)
        {
            return hints.Count == 4  && hints.TrueForAll(hint => hint == Hint.Black);
        }
    }
}