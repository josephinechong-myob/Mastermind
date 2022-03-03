using System.Collections.Generic;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Game //mastermind
    {
        private int _gameCount;
        private int _guessesCount;
        private readonly GameDialogue _gameDialogue;
        private readonly Codemaker _codemaker; //game
        
        //game evaluator class?
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator) //pass in only game??
        {
            _gameCount = 0; //reset game
            _guessesCount = 0; //60
            _gameDialogue = new GameDialogue(console);
            _codemaker = new Codemaker(randomNumberGenerator);
        }
        
        // function/method Check(array/List)

        public void Run() //mastermind (game)
        {
            var playerWantsToPlayAgain = true;
            
            while(playerWantsToPlayAgain)
            {
                _guessesCount = 0;
                _codemaker.ResetColours(); //reset game need to reset guess counter and mastermind colours (test - list needs to be empty for mastermind to get new colours)
                Play();
                _gameCount++;
                playerWantsToPlayAgain = _gameDialogue.DoesPlayerWantToReplay();
            }
        }

        private void Play() //refactor to private
        {
            var hints = GetHint();

            if (PlayerHasWon(hints))
            {
                _gameDialogue.PrintAfterPlayerHasWon();
            }
            else
            {
                _gameDialogue.PrintCorrectColourSolution(_codemaker.GetColours());
            }
        }

        private bool PlayerHasWon(List<Hint> hints)
        {
            return hints.Count == Constants.MaximumNumberOfHints  && hints.TrueForAll(hint => hint == Hint.Black);
        }

        public int GetGameCount()
        {
            return _gameCount;
        }

        private List<Hint> GetHint() //Game + Check
        {
            var hints = new List<Hint>();
            
            while (_guessesCount < Constants.MaximumNumberOfColourGuesses && !PlayerHasWon(hints))
            {
                var player = new Codebreaker(); //nice to have: get player name
                //player.PlayerColoursGuesses = _gameDialogue.GetPlayersColourGuess(); <- getting players 
                player.UpdateGuesses(_gameDialogue.GetPlayersColourGuess());
                
                hints = _codemaker.CheckPlayerColoursGuess(player.CurrentGuess); // == game.check()
                
                _gameDialogue.PrintHints(hints);
                _gameDialogue.PrintGuessesCount(_guessesCount);
                
                _guessesCount++;
            }

            return hints;
        }
    }
    
    
}