using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Mastermind
    {
        private Colours _colours;
        private ColoursGenerator _coloursGenerator;

        private IRandomNumberGenerator _generator;
        //store the colours for mastermind

        public Mastermind(IRandomNumberGenerator randomNumberGenerator)
        {
            _coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _generator = randomNumberGenerator;
            _colours = _coloursGenerator.GenerateNew();
        }
        
        
        //check the guess
        //assembling a hint array?
        public List<Hint> CheckPlayerColoursGuess(List<Colour> playersColours)//playerinput
        {
            //compare players colours against mastermind
            
            //colours same colours present 
            //position of crrect colours
            
            //shuffle the hint 
            var hintProvider = new HintProvider(_generator);

            hintProvider.ProvideHints(playersColours, _colours.Get());//playerinput
            return new List<Hint>();
        }
        
        
        //only the mastermind knows what the colours are 
    }
}