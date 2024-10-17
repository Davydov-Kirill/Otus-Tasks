using GuessTheNumberLibrary;
using GuessTheNumberLibrary.Interfaces;

internal class Program
{
    private static void Main()
    {
        IInputService inputService = new ConsoleInputService();
        IOutputService outputService = new ConsoleOutputService();
        IGameSettings gameSettings = new GameSettings(5, 0, 10);
        IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

        Game game = new Game(inputService, outputService, randomNumberGenerator, gameSettings);

        outputService.HelloMessage();
        gameSettings.ShowSettings();

        bool isExit = default;

        while (!isExit)
        {
            Console.WriteLine("\nНажмите \"Enter\" чтобы начать или \"Esc\" чтобы выйти.");
            Console.WriteLine("Если вы хотите изменить настройки игры нажмите \"S\"");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    game.Start();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Хорошего дня! Возвращайтесь снова!");
                    isExit = true;
                    break;
                case ConsoleKey.S:
                    gameSettings.ChangeSettings();
                    continue;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                    break;
            }
        }

    }
}