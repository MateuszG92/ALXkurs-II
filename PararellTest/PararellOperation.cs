using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    internal class ParallelOperation
    {
        Random random = new Random();
        CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public void LoopParallelCancel()
        {
            new Thread(() => { 
                Thread.Sleep(3000); 
                cancellationToken.Cancel();
            }).Start();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 4;
            parallelOptions.CancellationToken = cancellationToken.Token;

            try
            {
                Parallel.For(0, 10, parallelOptions, i =>
                {
                    long total = LongOperation();
                    Console.WriteLine("{0} - {1}", i, total);
                    Thread.Sleep(2000);
                });
            } catch(OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            stopwatch.Stop();
            Console.WriteLine($"LoopParallel - {stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LoopNoParallel()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                long total = LongOperation();
                Console.WriteLine("{0} - {1}",i,total);
            }
            stopwatch.Stop();
            Console.WriteLine($"LoopNoParallel - {stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LoopParallel()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 4;
            Parallel.For(0, 10, parallelOptions, i =>
            {
                long total = LongOperation();
                Console.WriteLine("{0} - {1}", i, total);
            });
            stopwatch.Stop();
            Console.WriteLine($"LoopParallel - {stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LoopParallelForEach()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 4;
            List<int> integersList = Enumerable.Range(0, 10).ToList();
            Parallel.ForEach(integersList, parallelOptions, i =>
            {
                long total = LongOperation();
                Console.WriteLine("{0} - {1}", i, total);
            });
            stopwatch.Stop();
            Console.WriteLine($"LoopParallelForEach - {stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void LoopParallelBreakStop()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 4;
            Parallel.For(0, 10, parallelOptions, (i,loopState) =>
            {
                long total = LongOperation();
                Console.WriteLine("{0} - {1}", i, total);
                if (i >= 5)
                {
                    loopState.Break();
                }
            });
            stopwatch.Stop();
            Console.WriteLine($"LoopParallel - {stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void ParallelInvoke()
        {
            ParallelOptions options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 4
            };
            Parallel.Invoke(options,()=>TestTask(1), () => TestTask(2), () => TestTask(3), () => TestTask(4));
        }

        private long LongOperation()
        {
            long total = 0;
            for (int i = 0; i < 10000000; i++)
            {
                total += i;
            }
            return total;
        }
        private void TestTask(int number)
        {
            Console.WriteLine($"Start zadanie [{number}]");
            Thread.Sleep(random.Next(500,1200));
            Console.WriteLine($"Koniec zadania [{number}]");
        }
    }
}
