using System.Collections.Generic;

namespace mastermind
{
    public class Game
    {
        // randomisation of colors (4) - testing
        private readonly IConsole _console;
        private int _gameCount;
        private List<Colours> _mastermindColorsList;
        public Game(IConsole console)
        {
            _console = console;
            _gameCount = 0;
            _mastermindColorsList = new List<Colours>();
        }

        public void Run()
        {
            
        }

        private void Mastermind()
        {
            
        }
    }
}