namespace mastermind
{
    internal static class Program
    {
        private static void Main()
        { 
            var randomNumberGenerator = new RandomNumberGenerator.RandomNumberGenerator();
            var console = new GameConsole.GameConsole();
            var game = new Game.Game(console, randomNumberGenerator);
            game.Run();
        }
    }
}