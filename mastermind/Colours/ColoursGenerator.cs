using System;
using System.Collections.Generic;
using mastermind.Abstract;

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
                var randomColour = GetRandomColour();
                chosenColours.Add(randomColour);
            }

            return new ColoursList(chosenColours);
        }

        private Colour GetRandomColour()
        {
            var randomNumber = _randomNumberGenerator.NextRandom(Enum.GetNames(typeof(Colour)).Length);
            var randomColour = (Colour) randomNumber;
            return randomColour;
        }
    }
}