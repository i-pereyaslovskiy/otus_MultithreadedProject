using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otus_MultithreadedProject
{
    internal static class SumOptions
    {
        public static long Sum(int[] arr)
        {
            return arr.Sum(x => (long)x);
        }

        public static long ThreadSum(int[] arr)
        {
            long sum = 0;
            const int THREARS_ARRAY_SIZE = 3;
            int calculateCollectionSize = (arr.Length / THREARS_ARRAY_SIZE);

            for (int i = 0; i < THREARS_ARRAY_SIZE; i++)
            {
                if (i == THREARS_ARRAY_SIZE - 1)
                {
                    var t = new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Sum(x => (long)x)));
                    t.Start();
                    t.Join();
                }
                else
                {
                    var t = new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Take(calculateCollectionSize).Sum(x => (long)x)));
                    t.Start();
                    t.Join();
                }
            }
            return sum;
        }

        public static long ParallelLINQSum(int[] arr)
        {
            return arr.AsParallel().Sum(x => (long)x);
        }


        public static string ExecutionTimeCheck(Action method)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            stopwatch.Start();
            method.Invoke();
            stopwatch.Stop();

            return $"Execution time: {stopwatch.ElapsedMilliseconds} ms.";
        }

    }
}
