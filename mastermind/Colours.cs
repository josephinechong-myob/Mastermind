using System;
using System.Collections.Generic;

namespace mastermind
{
    public class Colours
    {
        public List<Colour> ColoursList;

        public Colours(List<Colour> coloursList)
        {
            ColoursList = coloursList;
        }
        
        public static Colours GenerateNew(int numberOfColours = 4)
        {
            var colours = ColourExtensions.GetColour();
            var chosenColours = new List<Colour>();
            Random rnd = new Random();
            
            for (var i = 0; i < numberOfColours; i++)
            {
                var randomNumber = rnd.Next(colours.Length);
                var randomColour = colours[randomNumber];
                chosenColours.Add(randomColour);
            }
            
            return new Colours(chosenColours);
        }
    }
}