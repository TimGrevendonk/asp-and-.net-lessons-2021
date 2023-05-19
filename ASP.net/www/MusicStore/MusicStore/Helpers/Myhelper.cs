namespace MusicStore.Helpers
{
    public class MyHelper
    {
        // Is used in "Home -> Index" for reference.
        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}
