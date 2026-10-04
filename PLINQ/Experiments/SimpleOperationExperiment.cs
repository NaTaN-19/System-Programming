using System.Diagnostics;

namespace ParallelLinq.Experiments;

public static class SimpleOperationExperiment
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 5_000_000);

        Stopwatch stopwatch = Stopwatch.StartNew();

        var linqResult = numbers
            .Select(x => x * 2)
            .ToList();

        stopwatch.Stop();

        long linqTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();

        var plinqResult = numbers
            .AsParallel()
            .Select(x => x * 2)
            .ToList();

        stopwatch.Stop();

        long plinqTime = stopwatch.ElapsedMilliseconds;

        double speedup = (double)linqTime / plinqTime;

        Console.WriteLine();
        Console.WriteLine("===== SIMPLE OPERATION =====");
        Console.WriteLine($"LINQ:  {linqTime} ms");
        Console.WriteLine($"PLINQ: {plinqTime} ms");
        Console.WriteLine($"Speedup: {speedup:F2}x");
    }
}
