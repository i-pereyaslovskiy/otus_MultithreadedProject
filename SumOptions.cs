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

            #region for
            // Если добавлять новые потоки в отдельную колекцию через цикл for,то замыкание не отработает и  
            // поток придется запускать в той же итерации.
            /*
             for (int i = 0; i < THREARS_ARRAY_SIZE; i++)
             {
                 Thread t;

                 if (i == THREARS_ARRAY_SIZE - 1)
                     t = new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Sum(x => (long)x)));
                 else
                     t = new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Take(calculateCollectionSize).Sum(x => (long)x)));

                 t.Start();
                 t.Join();
             }
            */
            #endregion

            // Для работы Замыкания оспользовать foreach
            List<Thread> threads = new List<Thread>();

            foreach (var i in Enumerable.Range(0, THREARS_ARRAY_SIZE))
            {
                if (i == THREARS_ARRAY_SIZE - 1)
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Sum(x => (long)x))));
                else
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, arr.Skip(i * calculateCollectionSize).Take(calculateCollectionSize).Sum(x => (long)x))));
            }

            foreach (var tread in threads)
            {
                tread.Start();
                tread.Join();
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
