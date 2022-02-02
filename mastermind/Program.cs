using System;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomNumberGenerator = new RandomNumberGenerator.RandomNumberGenerator();
            var console = new GameConsole();
            var game = new Game(console, randomNumberGenerator);
            game.Run();
        }
    }
}