using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Mastermind
    {
        private readonly Colours _colours;
        private readonly IRandomNumberGenerator _generator;

        public Mastermind(IRandomNumberGenerator randomNumberGenerator)
        {
            var coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            _colours = coloursGenerator.GenerateNew();
        }
        
        public List<Hint> CheckPlayerColoursGuess(List<Colour> playersColours)
        {
            var hintProvider = new HintProvider(_generator);
            var hints = hintProvider.ProvideHints(playersColours, _colours.Get());
            return hints;
        }

        public List<Colour> GetColours()
        {
            return _colours.Get();
        }
    }
}