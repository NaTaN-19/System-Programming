string[] files = Directory.GetFiles("Files", "*.txt");

FileProcessor fileProcessor = new FileProcessor();

FileStatistics[] statistics = new FileStatistics[files.Length];

Parallel.For(0, files.Length, i =>
{
    statistics[i] = fileProcessor.ProcessFile(files[i]);
});

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
