namespace mastermind
{
    class Program
    {
        private static void Main()
        { 
            var randomNumberGenerator = new RandomNumberGenerator.RandomNumberGenerator();
            var console = new GameConsole();
            var game = new Game(console, randomNumberGenerator);
            game.Run();
        }
    }
}