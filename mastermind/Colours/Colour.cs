namespace mastermind
{
    public enum Colour
    {
        RED,
        BLUE,
        GREEN,
        ORANGE,
        PURPLE,
        YELLOW
    }

    public static class ColourExtensions
    {
        public static Colour[] GetColour() //to-do 
        {
            return new Colour[]
            {
                Colour.RED,
                Colour.BLUE,
                Colour.GREEN,
                Colour.ORANGE,
                Colour.PURPLE,
                Colour.YELLOW
            };
        }
    }
}