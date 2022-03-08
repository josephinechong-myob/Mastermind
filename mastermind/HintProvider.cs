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
            
            for (var i = 0; i < playerColours.Count; i++)
            {
                for (var j = 0; j < mastermindColours.Count; j++)
                {
                    if (IndexIsNotIdenticalAndNotAlreadyMatched(i, j, indexOfMatchedMastermindColours) && SatisfiesWhiteHintConditions(i, j, playerColours, mastermindColours))
                    {
                        indexOfMatchedMastermindColours.Add(j);
                        yield return Hint.White;
                        break;
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
        
        /*
        public List<Hint> ProvideHints(List<Colour> playerColours, List<Colour> mastermindColours)
        {
            var filteredMasterMindColours = new List<Colour>();
            var filteredPlayerColours = new List<Colour>();
            
            var hintList = ProvideBlackHints(mastermindColours, playerColours, filteredPlayerColours, filteredMasterMindColours);
            hintList = ProvideWhiteHints(hintList, filteredPlayerColours, filteredMasterMindColours);
            
            return ProvideRandomHints(hintList);
        }
        
        private List<Hint> ProvideBlackHints(List<Colour>mastermindColours, List<Colour>playerColours, List<Colour>filteredPlayerColours, List<Colour>filteredMasterMindColours)
        {
            var hintList = new List<Hint>();
            
            for (int i = 0; i < mastermindColours.Count; i++)
            {
                if (playerColours[i] == mastermindColours[i])
                {
                    hintList.Add(Hint.Black);
                }
                else
                {
                    filteredMasterMindColours.Add(mastermindColours[i]);
                    filteredPlayerColours.Add(playerColours[i]);
                }
            }
            return hintList;
        }
        
        private List<Hint> ProvideWhiteHints(List<Hint> hintList, List<Colour>filteredPlayerColours, List<Colour>filteredMasterMindColours)
        {
            for (int i = 0; i < filteredMasterMindColours.Count; i++)
            {
                var foundColour = false;
                
                for (int j = 0; j < filteredPlayerColours.Count && !foundColour; j++)
                {
                    if (filteredPlayerColours[j] == filteredMasterMindColours[i])
                    {
                        hintList.Add(Hint.White);
                        filteredPlayerColours.RemoveAt(j);
                        foundColour = true;
                    }
                }
            }

            return hintList;
        }*/
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

//var randomisedHintList = hintList.OrderBy(item => _generator.NextRandom(hintList.Count)).ToList();
//white hint is find colour match - count black hints
/*var numberOfWhiteHints = filteredPlayerColours.Where(playerColour => filteredMasterMindColours.Any(mastermindColour => mastermindColour == playerColour)).ToList().Count;*/
//hintList.AddRange(Enumerable.Repeat(Hint.White, numberOfWhiteHints));