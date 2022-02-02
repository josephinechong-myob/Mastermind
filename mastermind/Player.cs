using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace mastermind
{
    public class Player
    {
        public List<List<Colour>> PlayersColoursGuesses;
        
        public Player()
        {
            PlayersColoursGuesses = new List<List<Colour>>();
        }
        
        //test for getplayercolourguess that you will recieve a list of colours TDD
        
        //1-60 guesses {4 colour} list, list of list 
        //list of guess class list of colours into guess class - count/guess ID/no and a list of the colours guessed
        
    }
}