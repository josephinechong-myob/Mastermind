using System.Collections.Generic;
using mastermind.Abstract;
using mastermind.Colours;
using mastermind.Hint;

namespace mastermind
{
    public class Codemaker
    {
        private ColoursList _coloursList;
        private readonly IRandomNumberGenerator _generator;
        private readonly ColoursGenerator _coloursGenerator;

        public Codemaker(IRandomNumberGenerator randomNumberGenerator)
        {
            _coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            _coloursList = _coloursGenerator.GenerateNew();
        }
        
        public List<Hint.Hint> CheckPlayerColoursGuess(List<Colour> playersColours)
        {
            var hintProvider = new HintProvider(_generator);
            var hints = hintProvider.ProvideHints(playersColours, _coloursList.Get());
            return hints;
        }

        public List<Colour> GetColours()
        {
            return _coloursList.Get();
        }

        public void ResetColours()
        {
            _coloursList = new ColoursList(new List<Colour>());
            _coloursList = _coloursGenerator.GenerateNew();
        }
    }
}