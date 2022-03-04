using System.Collections.Generic;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Game //mastermind
    {
        private readonly GameDialogue _gameDialogue;
        private readonly Codemaker _codemaker; //game
        private readonly Codebreaker _codebreaker;
        
        //game evaluator class?
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator) //pass in only game??
        {
            _gameDialogue = new GameDialogue(console);
            _codemaker = new Codemaker(randomNumberGenerator);
            _codebreaker = new Codebreaker();
        }
        
        // function/method Check(array/List)

        public void Run() //mastermind (game)
        {
            var playerWantsToPlayAgain = true;
            
            while(playerWantsToPlayAgain)
            {
                _codemaker.ResetColours();
                Play();
                playerWantsToPlayAgain = _gameDialogue.DoesPlayerWantToReplay();
            }
        }

        private void Play()
        {
            var hints = GetHint();
            
            //EvaluateGuesses

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

        private List<Hint> GetHint()
        {
            var hints = new List<Hint>();
            
            while (_codebreaker.Guesses.Count < Constants.MaximumNumberOfColourGuesses && !PlayerHasWon(hints))
            {
                _codebreaker.UpdateGuesses(_gameDialogue.GetPlayersColourGuess());
                hints = _codemaker.CheckPlayerColoursGuess(_codebreaker.CurrentGuess);
                
                _gameDialogue.PrintHints(hints);
                _gameDialogue.PrintGuessesCount(_codebreaker.Guesses.Count);
            }

            return hints;
        }
    }
}