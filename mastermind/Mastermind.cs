using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class Mastermind
    {
        private Colours _colours;
        private ColoursGenerator _coloursGenerator;
        //store the colours for mastermind

        public Mastermind(IRandomNumberGenerator randomNumberGenerator)
        {
            _coloursGenerator = new ColoursGenerator(randomNumberGenerator);
            _colours = _coloursGenerator.GenerateNew();
        }
        
        //check the guess
        
        //assembling a hint array?
        
        
        
        //only the mastermind knows what the colours are 
    }
}