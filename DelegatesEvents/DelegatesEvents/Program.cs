using DelegatesEvents;

public class Program
{
    private static void Main(string[] args)
    {
        var items = new List<Item>
        {
            new Item() { Name = "First", Value = 1.05f },
            new Item() { Name = "Second", Value = 14.23f },
            new Item() { Name = "Third", Value = 3.14f },
            new Item() { Name = "Fourth", Value = 5.73f },
        };

        Item maxItem = items.GetMax(item => item.Value);
        Console.WriteLine($"Максимальный элемент: {maxItem.Name} со значением {maxItem.Value}");

        var explorer = new FileExplorer();

        explorer.FileFound += (sender, e) =>
        {
            Console.WriteLine($"Файл найден: {e.FileName}");
            Thread.Sleep(1000);
        };

        Console.Write("Укажите путь к каталогу для получения информации о содержащихся файлах: ");
        string pathToExplore = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(pathToExplore) || !Directory.Exists(pathToExplore))
        {
            Console.WriteLine("Недопустимый путь. Проверьте указанный каталог.");
            return;
        }

        Task.Run(() =>
        {
            explorer.Explore(pathToExplore);
            Console.WriteLine("Исследование содержимого каталога завершено.");
        });

        Console.WriteLine("Нажмите 'Enter', чтобы отменить поиск...");
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                explorer.CancelSearch();
                Console.WriteLine("Поиск отменен.");
                break;
            }
        }
        Console.ReadKey();
    }
}