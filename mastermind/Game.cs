using System;
using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Game
    {
        private int _gameCount;
        private int _guessesCount;
        private Colours _colours;
        private IRandomNumberGenerator _randomNumberGenerator;
        private GameDialogue _gameDialogue;
        private Mastermind _mastermind;
        
        //game input console and that could store all the input and output you need for the game and a game input validator 
        //public colours MastermindsColours
        //public mastermind master - replace line 11
        //game evaluator class?
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _gameCount = 0;
            _guessesCount = 0;
            _colours = new Colours(new List<Colour>());//to do refactor for updated list
            _randomNumberGenerator = randomNumberGenerator;
            _gameDialogue = new GameDialogue(console);
            _mastermind = new Mastermind(_randomNumberGenerator);
        }

        public void Run()
        {
            var playerWantsToPlayAgain = true;
            
            while(playerWantsToPlayAgain)
            {
                Play();
                _gameCount++;
                playerWantsToPlayAgain = _gameDialogue.DoesPlayerWantToReplay();
            }
        }

        public void Play() //refactor to private
        {
            var hints = new List<Hint>();
            while (_guessesCount < 60 && !PlayerHasWon(hints))
            {
                var player = new Player();
            
                var playersColourGuess = 
                    _gameDialogue.GetPlayersColourGuess();
            
                hints = _mastermind.CheckPlayerColoursGuess(playersColourGuess);
            
                _gameDialogue.PrintHints(hints);
                _gameDialogue.PrintGuessesCount(_guessesCount);
                
                _guessesCount++;
            }

            if (PlayerHasWon(hints))
            {
                _gameDialogue.PrintAfterPlayerHasWon();
            }
            else
            {
                _gameDialogue.PrintCorrectColourSolution(_mastermind.GetColours());
            }
        }

        private bool PlayerHasWon(List<Hint> hints)
        {
            return hints.Count == 4  && hints.TrueForAll(hint => hint == Hint.Black);
        }

        public int GetGameCount()
        {
            return _gameCount;
        }
    }
}