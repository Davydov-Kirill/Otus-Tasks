using System.Security.Cryptography;
using GuessTheNumberLibrary.Interfaces;

namespace GuessTheNumberLibrary
{
    public class GameSettings : IGameSettings
    {
        private int _attemptsCount;
        private int _startRange;
        private int _endRange;

        public int AttemptsCount { get => _attemptsCount; }
        public int StartRange { get => _startRange; }
        public int EndRange { get => _endRange; }

        public void ShowSettings()
        {
            Console.WriteLine($"У вас будет {_attemptsCount} попыток угадать число в диапозоне от {_startRange} до {_endRange}.");
        }

        public GameSettings(int attemptsCount, int startRange, int endRange)
        {
            _attemptsCount = attemptsCount;
            _startRange = startRange;
            _endRange = endRange;
        }

        public void ChangeSettings()
        {

            bool attemptsCorrect = GetIntIput("Введите количество попыток: ", out int attemptsCount);
            bool startRangeCorrect = GetIntIput("Введите начальный диапозон: ", out int startRange);
            bool endRangeCorrect = GetIntIput("Введите конечный диапозон: ", out int endRange);

            if (attemptsCorrect && startRangeCorrect && endRangeCorrect && attemptsCount > 0 && startRange < endRange)
            {
                _attemptsCount = attemptsCount;
                _startRange = startRange;
                _endRange = endRange;
                Console.WriteLine("Настройки игры успешно изменены.");
                ShowSettings();
            }
            else
                Console.WriteLine("Не удалось изменить настройки игры. Попробуйте еще раз.");
        }

        private bool GetIntIput(string message, out int value)
        {
            Console.Write(message);
            return int.TryParse(Console.ReadLine(), out value);
        }

        public void ReduceAttemptsCount() => _attemptsCount--;
    }
}
