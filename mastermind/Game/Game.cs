using System.Collections.Generic;
using mastermind.Abstract;

namespace mastermind.Game
{
    public class Game
    {
        private readonly GameDialogue _gameDialogue;
        private readonly Codemaker _codemaker;
        private readonly Codebreaker _codebreaker;
        
        public Game(IGameConsole gameConsole, IRandomNumberGenerator randomNumberGenerator)
        {
            _gameDialogue = new GameDialogue(gameConsole);
            _codemaker = new Codemaker(randomNumberGenerator);
            _codebreaker = new Codebreaker();
        }

        public void Run()
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
            return _codebreaker.Guesses.Count < GameConstants.MaximumNumberOfColourGuesses && !PlayerHasWon(hints);
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
            return hints.Count == GameConstants.MaximumNumberOfHints  && hints.TrueForAll(hint => hint == Hint.Hint.Black);
        }
    }
}