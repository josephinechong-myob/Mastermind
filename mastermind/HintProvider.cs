using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    public class HintProvider
    {
        public HintProvider()
        {
            
        }
        //correct colour wrong position = white 
        //correct colour + position = black
        // incorrect = no colour/nothing
        
        //COLOUR present?
        //POSITIONING correct?

        public List<Hint> ProvideHints(List<Colour> playerColours, List<Colour> mastermindColours)
        {
            //black hint (4 blacks == winning mastermind)
            var hintList = new List<Hint>();
            var filteredMasterMindColours = new List<Colour>();
            var filteredPlayerColours = new List<Colour>();

            for (int i = 0; i < mastermindColours.Count; i++)
            {
                if (playerColours[i] == mastermindColours[i])
                {
                    hintList.Add(Hint.Black);
                    //mastermindColours.RemoveAt(i);
                    // playerColours.RemoveAt(i);
                }
                else
                {
                    filteredMasterMindColours.Add(mastermindColours[i]);
                    filteredPlayerColours.Add(playerColours[i]);
                }
            }

            //white hints - rewrite with fitlered mastermind first - could be order or try an loop - debug in l43 to see step by step how code works

            var numberOfWhiteHints = filteredPlayerColours.Where(playerColour =>
                filteredMasterMindColours.Any(mastermindColour => mastermindColour == playerColour)).ToList().Count;


            hintList.AddRange(Enumerable.Repeat(Hint.White, numberOfWhiteHints));
        



        // r r r g
        // r b b r

        // r r g
        // b b r



        //white hint 
        //count black hints =




        //no hints = nothing correct
        //randomise the hints
        return hintList;
        }
    }
}