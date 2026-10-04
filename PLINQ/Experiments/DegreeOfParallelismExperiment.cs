using System.Diagnostics;
using ParallelLinq.Calculations;

namespace ParallelLinq.Experiments;

public static class DegreeOfParallelismExperiment
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 5_000_000);

        int[] degrees = { 2, 4, 8, 16 };

        Console.WriteLine("===== DEGREE OF PARALLELISM =====");

        foreach (int degree in degrees)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = numbers
                .AsParallel()
                .WithDegreeOfParallelism(degree)
                .Select(HeavyCalculation.Calculate)
                .ToList();

            stopwatch.Stop();

            Console.WriteLine(
                $"Degree {degree}: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
