using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var result = numbers
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long linqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {linqTime} ms");


stopwatch.Restart();

var plinqResult = numbers
    .AsParallel()
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long plinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {plinqTime} ms");


Console.WriteLine();
Console.WriteLine("========== PERFORMANCE ==========");

Console.WriteLine($"LINQ:  {linqTime} ms");
Console.WriteLine($"PLINQ: {plinqTime} ms");

double speedup = (double)linqTime / plinqTime;

Console.WriteLine($"Speedup: {speedup:F2}x");








Console.WriteLine();
Console.WriteLine("========== DEGREE OF PARALLELISM ==========");

stopwatch.Restart();

var resultDop2 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(2)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 2: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop4 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(4)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 4: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop8 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(8)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 8: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop16 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 16: {stopwatch.ElapsedMilliseconds} ms");









Console.WriteLine();
Console.WriteLine("========== ORDER ==========");

var smallNumbers = Enumerable.Range(1, 100);

var unorderedResult = smallNumbers
    .AsParallel()
    .Select(x => x)
    .ToList();

Console.WriteLine("Without AsOrdered:");
Console.WriteLine(string.Join(", ", unorderedResult));


var orderedResult = smallNumbers
    .AsParallel()
    .AsOrdered()
    .Select(x => x)
    .ToList();

Console.WriteLine();
Console.WriteLine("With AsOrdered:");
Console.WriteLine(string.Join(", ", orderedResult));









Console.WriteLine();
Console.WriteLine("========== BONUS ==========");

stopwatch.Restart();

var simpleLinqResult = numbers
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simpleLinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {simpleLinqTime} ms");


stopwatch.Restart();

var simplePlinqResult = numbers
    .AsParallel()
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simplePlinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {simplePlinqTime} ms");



using System.Diagnostics;

var numbers = Enumerable.Range(1, 5_000_000);

static long HeavyCalculation(int number)
{
    long result = 0;

    for (int i = 1; i <= 10_000; i++)
    {
        result += (long)(number * i) % 1_234_567;
    }

    return result;
}

// LINQ

var stopwatch = Stopwatch.StartNew();

var result = numbers
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long linqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {linqTime} ms");


// PLINQ

stopwatch.Restart();

var plinqResult = numbers
    .AsParallel()
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

long plinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {plinqTime} ms");


// PERFORMANCE

Console.WriteLine();
Console.WriteLine("========== PERFORMANCE ==========");

Console.WriteLine($"LINQ:  {linqTime} ms");
Console.WriteLine($"PLINQ: {plinqTime} ms");

double speedup = (double)linqTime / plinqTime;

Console.WriteLine($"Speedup: {speedup:F2}x");


// DEGREE OF PARALLELISM

Console.WriteLine();
Console.WriteLine("========== DEGREE OF PARALLELISM ==========");

stopwatch.Restart();

var resultDop2 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(2)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 2: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop4 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(4)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 4: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop8 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(8)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 8: {stopwatch.ElapsedMilliseconds} ms");


stopwatch.Restart();

var resultDop16 = numbers
    .AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(HeavyCalculation)
    .ToList();

stopwatch.Stop();

Console.WriteLine($"DOP 16: {stopwatch.ElapsedMilliseconds} ms");


// ORDER EXPERIMENT

Console.WriteLine();
Console.WriteLine("========== ORDER EXPERIMENT ==========");

var smallNumbers = Enumerable.Range(1, 100);

var unorderedResult = smallNumbers
    .AsParallel()
    .Select(x => x)
    .ToList();

Console.WriteLine("Without AsOrdered:");
Console.WriteLine(string.Join(", ", unorderedResult));


var orderedResult = smallNumbers
    .AsParallel()
    .AsOrdered()
    .Select(x => x)
    .ToList();

Console.WriteLine();
Console.WriteLine("With AsOrdered:");
Console.WriteLine(string.Join(", ", orderedResult));


// BONUS

Console.WriteLine();
Console.WriteLine("========== BONUS ==========");

stopwatch.Restart();

var simpleLinqResult = numbers
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simpleLinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("LINQ:");
Console.WriteLine($"Time: {simpleLinqTime} ms");


stopwatch.Restart();

var simplePlinqResult = numbers
    .AsParallel()
    .Select(x => x * 2)
    .ToList();

stopwatch.Stop();

long simplePlinqTime = stopwatch.ElapsedMilliseconds;

Console.WriteLine("PLINQ:");
Console.WriteLine($"Time: {simplePlinqTime} ms");









//
// ANSWERS
//
// Why can PLINQ change the order?
// PLINQ processes different parts of the collection in parallel.
// Therefore, elements can finish processing in a different order.
//
// What is AsOrdered() used for?
// AsOrdered() tells PLINQ to preserve the original order
// of the source collection in the final result.
//
// Is there a cost to preserving order?
// Yes. PLINQ needs additional coordination to preserve the order,
// which can reduce the performance benefit of parallel execution.
//
// Why can PLINQ be significantly faster in the first test?
// HeavyCalculation performs many CPU-bound operations.
// Different elements can be calculated independently on different
// CPU cores, so parallel execution can reduce the total time.
//
// Why can PLINQ be slower in the second test?
// x * 2 is a very simple operation. The overhead of parallelization,
// partitioning and combining results can be greater than the work
// itself.
//
// When should PLINQ be used?
// PLINQ is useful when the collection is sufficiently large and
// each element requires enough CPU-bound work to justify
// parallel execution.
//
// When is PLINQ pointless?
// PLINQ may be pointless for very simple operations, small
// collections, or operations where parallelization overhead
// is greater than the computational work.
//
// Why does a large collection alone not guarantee acceleration?
// The amount of elements is only one factor. The amount of work
// performed for each element and the parallelization overhead
// also affect performance.
//
// Why are CPU-bound operations good candidates?
// CPU-bound operations can use multiple CPU cores simultaneously
// when the calculations are independent.
//
// How does AsOrdered() affect execution?
// AsOrdered() preserves the source order in the output, but this
// requires additional coordination and may reduce performance.
//
// Why is WithDegreeOfParallelism() used?
// It controls the maximum degree of parallelism used by PLINQ.
// Different values can produce different performance depending
// on the workload and the computer's CPU.
//
