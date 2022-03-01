using System.Collections.Generic;
using mastermind.Colours;

namespace mastermind
{
    public class Codebreaker //did not create an interface as did not want to to clutter codebase "YAGNI"
    {
        public List<Colour> PlayerColoursGuesses;
        
        public Codebreaker()
        {
            PlayerColoursGuesses = new List<Colour>();
        }
    }
}