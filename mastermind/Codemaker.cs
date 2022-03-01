using System.Collections.Generic;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Codemaker //code maker
    {
        private Colours.Colours _colours; //mastermind colours 
        private readonly IRandomNumberGenerator _generator;
        private readonly ColoursGenerator _coloursGenerator;

        public Codemaker(IRandomNumberGenerator randomNumberGenerator)
        {
            _coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            _colours = _coloursGenerator.GenerateNew();
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

        public void ResetColours()
        {
            _colours = new Colours.Colours(new List<Colour>());
            _colours = _coloursGenerator.GenerateNew();
        }
    }
}