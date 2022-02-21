using System;
namespace mastermind.RandomNumberGenerator
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int NextRandom(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }
    }
}