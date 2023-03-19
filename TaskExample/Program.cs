using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task task1 = new Task(TestTask);
            //task1.Start();

            //Task task2 = Task.Factory.StartNew(TestTask);

            //Task task3 = Task.Run(() => TestTask());

            //Task.WaitAll(new Task[] { task1, task2, task3 });
            //Task.WaitAny(new Task[] { task1, task2, task3 });

            //Task<int> task4=Task.Run(() => Add(10,20));
            //Console.WriteLine(task4.Result);
            //task4.ContinueWith(t1=> 
            //{
            //    var task5 = Task.Run(()=>Average(task4.Result,2));
            //    task5.ContinueWith(t2 =>
            //    {
            //        Console.WriteLine(t2.Result);
            //    });
            //});
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            cancellationTokenSource.CancelAfter(1000);
            Task cancel = Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(250);
                        Console.WriteLine($"Task iteracja nr {i}");
                        if (token.IsCancellationRequested)
                        {
                            token.ThrowIfCancellationRequested();
                        }
                    }
                }catch (OperationCanceledException ex)
                {
                    return;
                }
            }, token); 

            Console.WriteLine("Trwa wykonywania zadania #1");
            Console.ReadKey();
        }
        static void TestTask()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] count value = {i}");
                Thread.Sleep(1500);
            }
        }
        static int Add(int a, int b)
        {
            Console.WriteLine($"Liczenie sumy {a}+{b}");
            Thread.Sleep(1000);
            return a + b;
        }
        static float Average (int sum, int n)
        {
            Console.WriteLine($"Liczenie średniej {sum} dla {n} liczb");
            Thread.Sleep(1000);
            return sum / n;
        }
    }
}
