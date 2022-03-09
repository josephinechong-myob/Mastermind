using System;
using mastermind.Abstract;

namespace mastermind.Game
{
    public class GameGameConsole : IGameConsole
    {
        public void WriteLine(string writeLine)
        {
            Console.WriteLine(writeLine);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}