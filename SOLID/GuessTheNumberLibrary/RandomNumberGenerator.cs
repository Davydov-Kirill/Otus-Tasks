using GuessTheNumberLibrary.Interfaces;

namespace GuessTheNumberLibrary
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random;

        public RandomNumberGenerator() => _random = new Random();

        public int Generate(int minValue, int maxValue) => _random.Next(minValue, maxValue);
    }
}
