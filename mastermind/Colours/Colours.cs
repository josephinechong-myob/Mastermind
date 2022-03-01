using System.Collections.Generic;

namespace mastermind.Colours
{
    public class Colours
    {
        private readonly List<Colour> _coloursList;

        public Colours(List<Colour> coloursList)
        {
            _coloursList = coloursList;
        }

        public List<Colour> Get()
        {
            return _coloursList;
        }
    }
}