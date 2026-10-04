using System.Diagnostics;
using ParallelLinq.Calculations;

namespace ParallelLinq.Experiments;

public static class LinqVsPlinqExperiment
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 5_000_000);

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        var linqResult = numbers
            .Select(HeavyCalculation.Calculate)
            .ToList();

        stopwatch.Stop();

        long linqTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();

        var plinqResult = numbers
            .AsParallel()
            .Select(HeavyCalculation.Calculate)
            .ToList();

        stopwatch.Stop();

        long plinqTime = stopwatch.ElapsedMilliseconds;

        double speedup = (double)linqTime / plinqTime;

        Console.WriteLine("========== PERFORMANCE ==========");
        Console.WriteLine($"LINQ:  {linqTime} ms");
        Console.WriteLine($"PLINQ: {plinqTime} ms");
        Console.WriteLine($"Speedup: {speedup:F2}x");
    }
}
