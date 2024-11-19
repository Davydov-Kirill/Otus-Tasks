namespace GuessTheNumberLibrary.Interfaces
{
    public interface IOutputService
    {
        void HelloMessage();
        void NumberLessMessage();
        void NumberGreaterMessage();
        void SuccessMessage();
        void LoseMessage();
    }
}