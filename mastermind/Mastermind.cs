using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Mastermind
    {
        public Colours Colours { get; private set; }
        private readonly IRandomNumberGenerator _generator;

        public Mastermind(IRandomNumberGenerator randomNumberGenerator)
        {
            var coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            Colours = coloursGenerator.GenerateNew();
        }
        
        public List<Hint> CheckPlayerColoursGuess(List<Colour> playersColours)
        {
            var hintProvider = new HintProvider(_generator);
            var hints = hintProvider.ProvideHints(playersColours, Colours.Get());
            return hints;
        }
    }
}