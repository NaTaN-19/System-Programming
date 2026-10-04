class FileProcessor
{
    public FileStatistics ProcessFile(string filepath)
    {
        string fileText = File.ReadAllText(filepath);

        string[] words = fileText.Split(
            new[] { ' ', '\n', '\r', '\t' },
            StringSplitOptions.RemoveEmptyEntries);

        int characters = fileText.Length;
        int wordCount = words.Length;
        int lineCount = File.ReadAllLines(filepath).Length;
        int errorCount = words.Count(
            word => word.Equals("error", StringComparison.OrdinalIgnoreCase));

        FileStatistics statistics = new FileStatistics
        {
            Characters = characters,
            Words = wordCount,
            Lines = lineCount,
            Errors = errorCount
        };

        return statistics;
    }
}
