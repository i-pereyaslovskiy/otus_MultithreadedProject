
using otus_MultithreadedProject;

int[] arrSizes = { 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };



foreach (int arrSize in arrSizes)
{

    int[] arr = Enumerable.Range(0, arrSize).ToArray();

    Console.WriteLine("Sequential:" + SumOptions.ExecutionTimeCheck(() => SumOptions.Sum(arr)));
    Console.WriteLine("Threads:" + SumOptions.ExecutionTimeCheck(() => SumOptions.ThreadSum(arr)));
    Console.WriteLine("LINQ:" + SumOptions.ExecutionTimeCheck(() => SumOptions.ParallelLINQSum(arr)));

    Console.WriteLine();
}




