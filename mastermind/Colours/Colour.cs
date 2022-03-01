namespace mastermind.Colours
{
    public enum Colour
    {
        Red,
        Blue,
        Green,
        Orange,
        Purple,
        Yellow
    }

    public static class ColourExtensions
    {
        public static Colour[] GetColour() //to-do 
        {
            return new Colour[]
            {
                Colour.Red,
                Colour.Blue,
                Colour.Green,
                Colour.Orange,
                Colour.Purple,
                Colour.Yellow
            };
        }
    }
}