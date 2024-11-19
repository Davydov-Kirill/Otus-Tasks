using GuessTheNumberLibrary.Interfaces;

namespace GuessTheNumberLibrary
{
    public class ConsoleOutputService : IOutputService
    {
        public void HelloMessage()
        {
            Console.WriteLine("Добро пожаловать в игру \"Угадай число\".");
        }

        public void NumberLessMessage()
        {
            Console.WriteLine("Ваше число меньше загаданного");
        }

        public void NumberGreaterMessage()
        {
            Console.WriteLine("Ваше число больше загаданного.");
        }

        public void SuccessMessage()
        {
            Console.WriteLine("Поздравляю, вы угадали число!");
        }

        public void LoseMessage()
        {
            Console.WriteLine("К сожелению вам не удалось угадать число.");
        }
    }
}