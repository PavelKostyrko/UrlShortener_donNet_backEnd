namespace UrlShortener.Logic.AuxiliaryСlasses
{
    public static class Shortener
    {
        private const int numberOfChars = 6;
        private const string alphabetAndNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdifghijklmnopqrstuvwxyz1234567890";
        private readonly static Random rand = new();

        /// <summary> Create a random shortlink with 6 chars. </summary>
        /// <returns> Returns a shortlink containing "short.by/" and 6 random chars. </returns>
        public static string CreateShortLink()
        {
            var chars = new char[numberOfChars];

            for (int i = 0; i < numberOfChars; i++)
            {
                chars[i] = alphabetAndNumbers[rand.Next(0, alphabetAndNumbers.Length - 1)];
            }

            return $"short.by/{new string(chars)}";
        }
    }
}
