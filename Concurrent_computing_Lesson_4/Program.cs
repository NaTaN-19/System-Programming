string[] files = Directory.GetFiles("Files", "*.txt");

FileProcessor fileProcessor = new FileProcessor();

Thread[] threads = new Thread[files.Length];
FileStatistics[] statistics = new FileStatistics[files.Length];

for (int i = 0; i < files.Length; i++)
{
    int index = i;

    threads[index] = new Thread(() =>
    {
        statistics[index] = fileProcessor.ProcessFile(files[index]);
    });

    threads[index].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

List<FileStatistics> statisticsList = statistics.ToList();

for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine(files[i]);
    Console.WriteLine($"  Characters: {statistics[i].Characters}");
    Console.WriteLine($"  Words: {statistics[i].Words}");
    Console.WriteLine($"  Lines: {statistics[i].Lines}");
    Console.WriteLine($"  Errors: {statistics[i].Errors}");
    Console.WriteLine();
}

FileStatisticsCalculator calculator = new FileStatisticsCalculator();
FileStatistics total = calculator.CalculateTotal(statisticsList);

Console.WriteLine("===== TOTAL =====");
Console.WriteLine();
Console.WriteLine($"Files: {files.Length}");
Console.WriteLine($"Characters: {total.Characters}");
Console.WriteLine($"Words: {total.Words}");
Console.WriteLine($"Lines: {total.Lines}");
Console.WriteLine($"Errors: {total.Errors}");
