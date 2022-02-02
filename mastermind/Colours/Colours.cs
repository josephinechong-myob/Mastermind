using System;
using System.Collections.Generic;

namespace mastermind
{
    public class Colours
    {
        private List<Colour> _coloursList;

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