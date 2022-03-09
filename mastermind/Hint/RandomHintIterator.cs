using System.Collections.Generic;
using mastermind.Abstract;

namespace mastermind.Hint
{
    public class RandomHintIterator : IIterator<Hint>
    {
        private readonly IRandomNumberGenerator _generator;
        private readonly List<mastermind.Hint.Hint> _hints;

        public RandomHintIterator(List<mastermind.Hint.Hint> hints, IRandomNumberGenerator generator)
        {
            _generator = generator;
            _hints = hints;
        }
        
        public bool HasNext()
        {
            return _hints.Count != 0;
        }

        public mastermind.Hint.Hint GetNext()
        {
            var randomIndex = _generator.NextRandom(_hints.Count);
            var randomHint = _hints[randomIndex];
            _hints.RemoveAt(randomIndex);
            return randomHint;
        }
    }
}