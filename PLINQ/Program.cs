using ParallelLinq.Experiments;

Console.WriteLine("========== PLINQ EXPERIMENTS ==========");

LinqVsPlinqExperiment.Run();

Console.WriteLine();

DegreeOfParallelismExperiment.Run();

Console.WriteLine();

OrderingExperiment.Run();

Console.WriteLine();

SimpleOperationExperiment.Run();
