using System;

internal class Program
{
    /*
    На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
    Программа рандомно генерирует число, пользователь должен угадать это число. 
    При каждом вводе числа программа пишет больше или меньше отгадываемого. 
    Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
    В отчёте написать, что именно сделано по каждому принципу.
    Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.
     */

    private static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру \"Угадай число\"");
        int attempts = 5;
        int startRange = 0;
        int endRange = 10;
        Console.WriteLine($"У вас будет {attempts} попыток угадать число в диапозоне от {startRange} до {endRange}");
        while (true)
        {
            Console.WriteLine("Нажмите \"Enter\" чтобы начать");
            Console.WriteLine("Если вы хотите изменить настройки игры нажмите \"S\"");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); 
            // true значит, что нажатая клавиша не будет выводиться в консоль

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Начинаем игру!");
                // Запускаем игру
                break;
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                Console.WriteLine("Изменение настроек игры...");
                Console.Write("Введите количество попыток: ");
                int.TryParse(Console.ReadLine(), out attempts);
                Console.Write("Введите начальный диапозон: ");
                int.TryParse(Console.ReadLine(), out startRange);
                Console.Write("Введите конечный диапозон: ");
                int.TryParse(Console.ReadLine(), out endRange);
                Console.WriteLine($"У вас будет {attempts} попыток угадать число в диапозоне от {startRange} до {endRange}");
                continue;
            }
            else Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
        }




    }
}