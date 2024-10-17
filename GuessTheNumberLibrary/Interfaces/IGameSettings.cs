namespace GuessTheNumberLibrary.Interfaces
{
    public interface IGameSettings
    {
        int AttemptsCount { get; }
        int EndRange { get; }
        int StartRange { get; }

        void ShowSettings();

        void ChangeSettings();

        void ReduceAttemptsCount();
    }
}