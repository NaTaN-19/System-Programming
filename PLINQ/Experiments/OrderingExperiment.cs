namespace ParallelLinq.Experiments;

public static class OrderingExperiment
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 100);

        var unorderedResult = numbers
            .AsParallel()
            .Select(x => x)
            .ToList();

        Console.WriteLine("===== UNORDERED =====");

        Console.WriteLine(
            string.Join(", ", unorderedResult));

        var orderedResult = numbers
            .AsParallel()
            .AsOrdered()
            .Select(x => x)
            .ToList();

        Console.WriteLine();
        Console.WriteLine("===== ORDERED =====");

        Console.WriteLine(
            string.Join(", ", orderedResult));
    }
}
