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

        public ColoursList GenerateNew(int numberOfColours = 4)
        {
            var chosenColours = new List<Colour>();

            for (var i = 0; i < numberOfColours; i++)
            {
                var randomNumber = _randomNumberGenerator.NextRandom(Enum.GetNames(typeof(Colour)).Length);
                var randomColour = (Colour)randomNumber;
                chosenColours.Add(randomColour);
            }

            return new ColoursList(chosenColours);
        }
    }
}