using System.Collections.Generic;

namespace mastermind.Colours
{
    public class ColoursList
    {
        private readonly List<Colour> _coloursList;

        public ColoursList(List<Colour> coloursList)
        {
            _coloursList = coloursList;
        }

        public List<Colour> Get()
        {
            return _coloursList;
        }
    }
}