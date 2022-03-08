using System.Collections.Generic;
using mastermind.Colours;
using mastermind.GameConsole;
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
            var hints = new List<Hint.Hint>();
            
            while(IsGameIncomplete(hints))
            {
                hints = PlayRound();
                PrintPostRoundInformation(hints);
            }
            
            DisplayGameOutcome(hints);
        }

        private bool IsGameIncomplete(List<Hint.Hint> hints)
        {
            return _codebreaker.Guesses.Count < Constants.MaximumNumberOfColourGuesses && !PlayerHasWon(hints);
        }

        private List<Hint.Hint> PlayRound()
        {
            _codebreaker.UpdateGuesses(_gameDialogue.GetPlayersColourGuess());
            return _codemaker.CheckPlayerColoursGuess(_codebreaker.CurrentGuess);
        }

        private void PrintPostRoundInformation(List<Hint.Hint> hints)
        {
            _gameDialogue.PrintHints(hints);
            _gameDialogue.PrintGuessesCount(_codebreaker.Guesses.Count); //you guess this number of times and have this many remaining guesses
        }

        private void DisplayGameOutcome(List<Hint.Hint> hints)
        {
            if (PlayerHasWon(hints))
            {
                _gameDialogue.PrintAfterPlayerHasWon();
            }
            else
            {
                _gameDialogue.PrintCorrectColourSolution(_codemaker.GetColours());
            } 
        }

        private bool PlayerHasWon(List<Hint.Hint> hints)
        {
            return hints.Count == Constants.MaximumNumberOfHints  && hints.TrueForAll(hint => hint == Hint.Hint.Black);
        }
    }
}