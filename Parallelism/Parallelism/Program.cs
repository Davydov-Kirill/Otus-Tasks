using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        RunAsyncTask(Path.Combine(Environment.CurrentDirectory, "Text")).GetAwaiter().GetResult();
        stopwatch.Stop();
        Console.WriteLine($"Время на считывание файлов и подсчета количества пробелов: {stopwatch.ElapsedMilliseconds}");
        Console.ReadKey();
    }

    private static async Task RunAsyncTask(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine(nameof(folderPath), "Искомая папка не существует!");
            return;
        }

        var files = Directory.GetFiles(folderPath);

        if (files.Length == 0)
        {
            Console.WriteLine("Нет файлов для обработки в указанной папке.");
            return;
        }

        Task<int>[] tasks = files.Select(f => CountSpacesInFileAsync(f)).ToArray();

        var results = await Task.WhenAll(tasks);

        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"Количество пробелов в файле {Path.GetFileName(files[i])}: {results[i]}");
        }
        Console.WriteLine($"Обработано файлов: {files.Length}");
    }

    private static async Task<int> CountSpacesInFileAsync(string filePath)
    {
        try
        {
            Console.WriteLine($"Начало асинхронного подсчета количества пробелов в файле {Path.GetFileName(filePath)}");
            string content = await File.ReadAllTextAsync(filePath);
            await Task.Delay(1000);
            int result = content.Count(c => c == ' ');
            Console.WriteLine($"Завершение асинхронного подсчета количества пробелов в файле {Path.GetFileName(filePath)}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла: {Path.GetFileName(filePath)}: {ex.Message}");
            return 0;
        }
    }
}