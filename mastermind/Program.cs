using mastermind.Game;

namespace mastermind
{
    internal static class Program
    {
        private static void Main()
        { 
            var randomNumberGenerator = new RandomNumberGenerator();
            var console = new GameGameConsole();
            var game = new Game.MastermindGame(console, randomNumberGenerator);
            game.Run();
        }
    }
}