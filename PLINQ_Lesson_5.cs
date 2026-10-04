using System.Diagnostics;

var numbers = Enumerable.Range(1, 5_000_000);


// 2. HEAVY CPU OPERATION

static long HeavyCalculation(int number)
{
    long result = 0;

    for (int i = 1; i <= 10_000; i++)
    {
        result += (long)number * i % 1_234_567;
    }

    return result;
}


// 3. ORDINARY LINQ

var stopwatch = Stopwatch.StartNew();

var result = numbers
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long linqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {linqTime} ms");


// 4. PLINQ

stopwatch.Restart();

var plinqResult = numbers
    .AsParallel()
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long plinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine();
Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {plinqTime} ms");


// 5. PERFORMANCE COMPARISON

Console.WriteLine();
Console.WriteLine("========== PERFORMANCE ==========");

Console.WriteLine($"LINQ:  {linqTime} ms");
Console.WriteLine($"PLINQ: {plinqTime} ms");

double speedup = (double)linqTime / plinqTime;

Console.WriteLine($"Speedup: {speedup:F2}x");


// 6. DEGREE OF PARALLELISM

Console.WriteLine();
Console.WriteLine("========== DEGREE OF PARALLELISM ==========");


// DOP 2

stopwatch.Restart();

var resultDop2 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(2)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 2:  {stopwatch.ElapsedMilliseconds} ms");


// DOP 4

stopwatch.Restart();

var resultDop4 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(4)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 4:  {stopwatch.ElapsedMilliseconds} ms");


// DOP 8

stopwatch.Restart();

var resultDop8 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(8)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 8:  {stopwatch.ElapsedMilliseconds} ms");


// DOP 16

stopwatch.Restart();

var resultDop16 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 16: {stopwatch.ElapsedMilliseconds} ms");


// 7. ORDER EXPERIMENT

Console.WriteLine();
Console.WriteLine("========== ORDER EXPERIMENT ==========");

var smallNumbers = Enumerable.Range(1, 100);


// Without AsOrdered

var unorderedResult = smallNumbers
    .AsParallel()
    .Select(x => x)
    .ToList();

Console.WriteLine("Without AsOrdered:");
Console.WriteLine(string.Join(", ", unorderedResult));


// With AsOrdered

var orderedResult = smallNumbers
    .AsParallel()
    .AsOrdered()
    .Select(x => x)
    .ToList();

Console.WriteLine();
Console.WriteLine("With AsOrdered:");
Console.WriteLine(string.Join(", ", orderedResult));


// BONUS
// Simple operation: x * 2

Console.WriteLine();
Console.WriteLine("========== BONUS ==========");


// Simple LINQ

stopwatch.Restart();

var simpleLinqResult = numbers
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simpleLinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {simpleLinqTime} ms");


// Simple PLINQ

stopwatch.Restart();

var simplePlinqResult = numbers
    .AsParallel()
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simplePlinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine();
Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {simplePlinqTime} ms");


// WRITTEN ANSWERS

/*
1. Why can PLINQ change the order?

PLINQ processes different parts of the collection in parallel.
Different parts can finish at different times, so PLINQ does not
guarantee the original order unless ordering is requested.


2. What is AsOrdered() used for?

AsOrdered() tells PLINQ to preserve the original order of the
source collection in the output.


3. Is there a cost to preserving order?

Yes. Preserving order requires additional coordination between
the parallel operations, which can add overhead and may reduce
the performance benefit of parallel execution.


4. Why can PLINQ be significantly faster in the first test?

HeavyCalculation performs many CPU-bound mathematical operations.
The calculations for different numbers are independent, so
multiple CPU cores can process different numbers in parallel.


5. Why can PLINQ be slower or provide little benefit in the
   second test?

The operation x * 2 is extremely simple. The overhead of
parallelization, partitioning, scheduling and combining results
can be greater than the actual calculation.


6. When should PLINQ be used?

PLINQ should be considered when there is a sufficiently large
amount of independent CPU-bound work and the cost of parallel
execution is justified by the amount of computation.


7. When is PLINQ pointless?

PLINQ may be pointless or slower for small collections,
very simple operations, or workloads where parallelization
overhead is greater than the useful computation.


8. Why does a large collection alone not guarantee acceleration?

The number of elements is only one factor. The amount of work
performed for each element and the overhead of parallel execution
also affect performance.


9. Why are CPU-bound operations good candidates?

CPU-bound operations spend significant time using the processor.
If the operations are independent, multiple CPU cores can perform
different calculations simultaneously.


10. How does AsOrdered() affect execution?

AsOrdered() requires PLINQ to preserve the source order in the
result. This can require additional coordination and may reduce
parallel efficiency.


11. Why is WithDegreeOfParallelism() used?

WithDegreeOfParallelism() controls the maximum degree of
parallelism used by PLINQ. Testing different values can show
which level provides the best performance for a particular
workload and computer.


12. Main conclusion:

PLINQ is useful when a sufficiently large amount of independent
CPU-bound work can be divided between multiple processors or
cores.

PLINQ is not necessarily useful for small collections or simple
operations because the overhead of parallelization can exceed
the benefit.

A large collection alone does not guarantee acceleration because
the amount of computation per element and the parallelization
overhead are also important.

CPU-bound operations are good candidates because independent
calculations can run simultaneously on multiple CPU cores.

AsOrdered() preserves the original order but can introduce
additional coordination overhead.

WithDegreeOfParallelism() allows us to control the maximum level
of parallelism and compare different settings.
*/
