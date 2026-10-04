string[] files = Directory.GetFiles("Files", "*.txt");

FileProcessor fileProcessor = new FileProcessor();

List<FileStatistics> statisticsList = new List<FileStatistics>();

Thread[] threads = new Thread[files.Length];

foreach (string file in files)
{
    FileStatistics statistics = fileProcessor.ProcessFile(file);
    statisticsList.Add(statistics);
}
