using System;
using System.Collections.Generic;
using mastermind.RandomNumberGenerator;

namespace mastermind.Colours
{
    public class ColoursGenerator
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public ColoursGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public ColoursList GenerateNew(int numberOfColours = 4) //could it be made static (static methods can't use fields and we need to use random number generator in lin 20)
        {
            //var colours = ColourExtensions.GetColour();
            
            var chosenColours = new List<Colour>();

            for (var i = 0; i < numberOfColours; i++)
            {
                var randomNumber = _randomNumberGenerator.NextRandom(Enum.GetNames(typeof(Colour)).Length); //enum length
                var randomColour = (Colour)randomNumber; //getting the new colour from enum list
                chosenColours.Add(randomColour);
            }

            return new ColoursList(chosenColours);
        }
    }
}