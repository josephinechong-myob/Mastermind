using System.Collections.Generic;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Codemaker
    {
        private Colours.ColoursList _coloursList; //mastermind colours 
        private readonly IRandomNumberGenerator _generator;
        private readonly ColoursGenerator _coloursGenerator;

        public Codemaker(IRandomNumberGenerator randomNumberGenerator)
        {
            _coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            _coloursList = _coloursGenerator.GenerateNew();
        }
        
        public List<Hint> CheckPlayerColoursGuess(List<Colour> playersColours)
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
            _coloursList = new Colours.ColoursList(new List<Colour>());
            _coloursList = _coloursGenerator.GenerateNew();
        }
    }
}