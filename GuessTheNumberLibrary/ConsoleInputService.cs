using GuessTheNumberLibrary.Interfaces;

namespace GuessTheNumberLibrary
{
    public class ConsoleInputService : IInputService
    {
        public int GetGuess()
        {
            int guess;
            while (true)
            {
                Console.Write("Введите ваше число: ");
                string input = Console.ReadLine();

                try
                {
                    guess = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Число слишком большое или слишком маленькое. Пожалуйста, введите корректное значение.");
                }
            }
            return guess;
        }
    }
}
