
using otus_MultithreadedProject;

Console.WriteLine("OS Version: " + Environment.OSVersion);
Console.WriteLine("Processor Count: " + Environment.ProcessorCount);
Console.WriteLine(".NET Version: " + Environment.Version);
Console.WriteLine();

int[] arrSizes = { 100_000, 1_000_000, 10_000_000 };



foreach (int arrSize in arrSizes) {

    int[] arr = Enumerable.Range(0, arrSize).ToArray();

    Console.WriteLine("Sequential:" + SumOptions.ExecutionTimeCheck(() => SumOptions.Sum(arr)));
    Console.WriteLine("Parallel:" + SumOptions.ExecutionTimeCheck(() => SumOptions.ThreadSum(arr)));
    Console.WriteLine("LINQ:" + SumOptions.ExecutionTimeCheck(() => SumOptions.ParallelLINQSum(arr)));

    Console.WriteLine();
}




