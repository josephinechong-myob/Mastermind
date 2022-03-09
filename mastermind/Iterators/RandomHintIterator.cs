using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind.Iterators
{
    public class RandomHintIterator : IIterator<Hint.Hint>
    {
        private readonly IRandomNumberGenerator _generator;
        private readonly List<Hint.Hint> _hints;

        public RandomHintIterator(List<Hint.Hint> hints, IRandomNumberGenerator generator)
        {
            _generator = generator;
            _hints = hints;
        }
        
        public bool HasNext()
        {
            return _hints.Count != 0;
        }

        public Hint.Hint GetNext()
        {
            var randomIndex = _generator.NextRandom(_hints.Count);
            var randomHint = _hints[randomIndex];
            _hints.RemoveAt(randomIndex);
            return randomHint;
        }
    }
}