using System.Collections.Generic;
using mastermind.Colours;

namespace mastermind
{
    public class Codebreaker 
    {
        public List<Colour> PlayerColoursGuesses;
        
        public Codebreaker()
        {
            PlayerColoursGuesses = new List<Colour>();
        }
    }
}