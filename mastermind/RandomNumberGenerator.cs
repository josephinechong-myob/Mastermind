using System;
using mastermind.Abstract;

namespace mastermind
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int NextRandom(int max)
        {
            var rnd = new Random();
            return rnd.Next(max);
        }
    }
}