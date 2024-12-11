
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Environment.ProcessorCount);

        int[] sizes = { 100_000, 1_000_000, 10_000_000 };

        foreach (int size in sizes)
        {
            int[] number = GenerateRandomArray(size);

            Console.WriteLine($"Array size: {size}");

            MeasureExecutionTime("Sum (Sequential)", () => SumSequential(number));
            MeasureExecutionTime("Sum (Parallel with Threads)", () => SumParallelThread(number));
            MeasureExecutionTime("Sum (Parallel with LINQ)", () => SumParallelLINQ(number));
        }
    }

    private static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 100);
        }
        return array;
    }

    private static long SumSequential(int[] array)
    {
        long sum = 0;
        foreach (int item in array)
        {
            sum += item;
        }
        return sum;
    }

    private static long SumParallelThread(int[] array)
    {
        int length = array.Length;
        int threadCount = Environment.ProcessorCount;
        int chunkSize = (length + threadCount - 1) / threadCount;

        long[] partialSums = new long[threadCount];
        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            int start = i * chunkSize;
            int end = Math.Min(start + chunkSize, length);
            int index = i;

            threads[i] = new Thread(() =>
            {
                long localSum = 0;
                for (int j = start; j < end; j++)
                {
                    localSum += array[j];
                }
                partialSums[index] = localSum;
            });
            threads[i].Start();
        }

        foreach (var thread in threads)
        {

            thread.Join();
        }

        long totalSum = 0;
        foreach (var sum in partialSums)
        {
            totalSum += sum;
        }

        return totalSum;
    }

    private static long SumParallelLINQ(int[] array)
    {
        return array.AsParallel().Sum(x => (long)x);
    }

    private static void MeasureExecutionTime(string description, Func<long> func)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        long result = func();
        stopwatch.Stop();
        Console.WriteLine($"{description}: {result} (Time: {stopwatch.ElapsedMilliseconds} ms)");
    }
}