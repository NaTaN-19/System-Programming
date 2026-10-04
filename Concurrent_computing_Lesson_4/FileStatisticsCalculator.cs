class FileStatisticsCalculator
{
    public FileStatistics CalculateTotal(List<FileStatistics> statisticsList)
    {
        FileStatistics total = new FileStatistics();

        foreach (FileStatistics statistics in statisticsList)
        {
            total.Characters += statistics.Characters;
            total.Words += statistics.Words;
            total.Lines += statistics.Lines;
            total.Errors += statistics.Errors;
        }
        return total;
    }

}
