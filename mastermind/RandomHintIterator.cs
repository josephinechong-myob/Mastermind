using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class RandomHintIterator : IIterator<Hint>
    {
        private IRandomNumberGenerator _generator;
        private List<Hint> _hints;

        public RandomHintIterator(List<Hint> hints, IRandomNumberGenerator generator)
        {
            _generator = generator;
            _hints = hints;
        }
        
        public bool HasNext()
        {
            return _hints.Count != 0;
        }

        public Hint GetNext()
        {
            var randomIndex = _generator.NextRandom(_hints.Count);
            var randomHint = _hints[randomIndex];
            _hints.RemoveAt(randomIndex);
            return randomHint;
        }
    }
}