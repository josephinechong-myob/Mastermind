using System.Collections.Generic;
using System.Linq;
using mastermind.Colours;
using mastermind.RandomNumberGenerator;

namespace mastermind
{
    public class HintProvider
    {
        private readonly IRandomNumberGenerator _generator;
        public HintProvider(IRandomNumberGenerator generator)
        {
            _generator = generator;
        }
        public List<Hint> ProvideHints(List<Colour> playerColours, List<Colour> mastermindColours)
        {
            var blackHints = ProvideBlackHints(mastermindColours, playerColours);
            var whiteHints = ProvideWhiteHints(mastermindColours, playerColours).ToList();
            var hints = blackHints.Concat(whiteHints).ToList();
            
            return ProvideRandomHints(hints);
        }
        
        private List<Hint> ProvideBlackHints(List<Colour>mastermindColours, List<Colour>playerColours)
        {
            var hintList = new List<Hint>();
            
            for (int i = 0; i < mastermindColours.Count; i++)
            {
                if (playerColours[i] == mastermindColours[i])
                {
                    hintList.Add(Hint.Black);
                }
            }
            return hintList;
        }
        
        private IEnumerable<Hint> ProvideWhiteHints(List<Colour>mastermindColours, List<Colour>playerColours) //yield return 
        {
            var indexOfMatchedMastermindColours = new List<int>();

            for (var i = 0; i < playerColours.Count; i++) //refacore to not have a nested loop?
            {
                var previousMatchColoursCount = indexOfMatchedMastermindColours.Count;
                
                for (var j = 0; j < mastermindColours.Count && previousMatchColoursCount == indexOfMatchedMastermindColours.Count ; j++)
                {
                    if (IndexIsNotIdenticalAndNotAlreadyMatched(i, j, indexOfMatchedMastermindColours) && SatisfiesWhiteHintConditions(i, j, playerColours, mastermindColours))
                    {
                        indexOfMatchedMastermindColours.Add(j);
                        yield return Hint.White;
                    } 
                }
            }
        }

        private bool IndexIsNotIdenticalAndNotAlreadyMatched(int i, int j, List<int> indexOfMatchedMastermindColours)
        {
            return i != j && !indexOfMatchedMastermindColours.Contains(j);
        }

        private bool SatisfiesWhiteHintConditions(int i, int j, List<Colour> playerColours, List<Colour> mastermindColours)
        {
            return mastermindColours[j] == playerColours[i] && mastermindColours[j] != playerColours[j] &&
                   mastermindColours[i] != playerColours[i];
        }
        
        private List<Hint> ProvideRandomHints(List<Hint> hintList)
        {
            var randomHintIterator = new RandomHintIterator(hintList, _generator);
            var randomHints = new List<Hint>();
            
            while (randomHintIterator.HasNext())
            {
                var hint = randomHintIterator.GetNext();
                randomHints.Add(hint);
            }
            
            return randomHints;
        }
    }
}