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
        public static long Sum(int[]arr)
        {
            return arr.Sum(x => (long)x);
        }

        public static long ThreadSum(int[] arr) {
            long sum = 0;

            Thread thread = new Thread(()=> 
            {
                sum = arr.Sum(x => (long)x);
            });
            thread.Start();
            thread.Join();
            
            return sum;
        }

        public static long ParallelLINQSum(int[] arr) {
            return arr.AsParallel().Sum(x => (long)x);
        }


        public static string ExecutionTimeCheck(Action method) {

            Stopwatch stopwatch = Stopwatch.StartNew();

            stopwatch.Start();
            method.Invoke();
            stopwatch.Stop();

            return $"Execution time: {stopwatch.ElapsedMilliseconds} ms.";
        }

    }
}
