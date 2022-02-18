using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    public class HintProvider
    {
        public HintProvider()
        {
            
        }
        public List<Hint> ProvideHints(List<Colour> playerColours, List<Colour> mastermindColours)
        {
            //black hint (4 blacks == winning mastermind)
            var hintList = new List<Hint>();
            var filteredMasterMindColours = new List<Colour>();
            var filteredPlayerColours = new List<Colour>();

            hintList = ProvideBlackHints(mastermindColours, playerColours, filteredMasterMindColours,
                filteredPlayerColours);

            hintList = ProvideWhiteHints(hintList, filteredMasterMindColours, filteredPlayerColours);
            
            //randomise the hints
            
            return hintList;
        }
        
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
    }
}