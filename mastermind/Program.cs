namespace mastermind
{
    internal static class Program
    {
        private static void Main()
        { 
            var randomNumberGenerator = new RandomNumberGenerator.RandomNumberGenerator();
            var console = new GameConsole.GameGameConsole();
            var game = new Game.MastermindGame(console, randomNumberGenerator);
            game.Run();
        }
    }
}