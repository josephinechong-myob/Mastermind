using System.Collections.Generic;
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
            var filteredMasterMindColours = new List<Colour>();
            var filteredPlayerColours = new List<Colour>();

            var hintList = ProvideBlackHints(mastermindColours, playerColours, filteredMasterMindColours, filteredPlayerColours);
            hintList = ProvideWhiteHints(hintList, filteredMasterMindColours, filteredPlayerColours);
            
            return ProvideRandomHints(hintList);
        }
        
        //var randomisedHintList = hintList.OrderBy(item => _generator.NextRandom(hintList.Count)).ToList();
        //white hint is find colour match - count black hints
        /*var numberOfWhiteHints = filteredPlayerColours.Where(playerColour => filteredMasterMindColours.Any(mastermindColour => mastermindColour == playerColour)).ToList().Count;*/
        //hintList.AddRange(Enumerable.Repeat(Hint.White, numberOfWhiteHints));
        
        private List<Hint> ProvideBlackHints(List<Colour>mastermindColours, List<Colour>playerColours, List<Colour>filteredMasterMindColours, List<Colour>filteredPlayerColours)
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

        private List<Hint> ProvideWhiteHints(List<Hint> hintList, List<Colour>filteredMasterMindColours, List<Colour>filteredPlayerColours)
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