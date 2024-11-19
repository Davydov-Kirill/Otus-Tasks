namespace GuessTheNumberLibrary.Interfaces
{
    public interface IRandomNumberGenerator
    {
        int Generate(int minValue, int maxValue);
    }
}