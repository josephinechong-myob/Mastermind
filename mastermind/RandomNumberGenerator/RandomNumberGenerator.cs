using System;
namespace mastermind.RandomNumberGenerator
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int Next(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }
    }
}