using System.Collections.Generic;
using System.Linq;
using mastermind.Colours;

namespace mastermind
{
    public class Codebreaker
    {
        public List<Colour> CurrentGuess => Guesses.Last().Get();
        public readonly List<ColoursList> Guesses;

        public Codebreaker()
        {
            Guesses = new List<ColoursList>();
        }
        
        public void UpdateGuesses(List<Colour> guess)
        {
            var colourlist = new ColoursList(guess);
            Guesses.Add(colourlist);
        }
    }
}