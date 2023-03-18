using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LongOeration(); synchronic

            Thread thread1 = new Thread(new ThreadStart(LongOeration));
            thread1.Priority=ThreadPriority.Normal;
            thread1.Start();

            Thread thread2 = new Thread(()=>LongOeration());
            thread2.Start();

            thread1.Abort();

            thread1.Join();
            thread2.Join(); 

            Console.WriteLine("Koniec pracy");
            Console.ReadKey();
        }

        static void LongOeration()
        {
            int threatId=Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{threatId} counter : {i}");
            }
        }
    }
}
