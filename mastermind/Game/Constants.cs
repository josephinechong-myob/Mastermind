namespace mastermind.Game
{
    public static class Constants
    {
        public const int MaximumNumberOfHints = 4;
        
        public const int MaximumNumberOfColourGuesses = 60;
        
        public const string ErrorMessageInvalidColour = "Error: you have given an invalid colour!";

        public const string ErrorMessageInvalidGuessLength = "Error: you must pass 4 colours!";

        public const string ErrorMessageExceeding60Attempts = "Error: you have had more than 60 tries!";

        public const string ErrorMessageInvalidYesOrNo = "Error: you have given an invalid entry. Please enter 'Y' - Yes or 'N' - No";
    }
}