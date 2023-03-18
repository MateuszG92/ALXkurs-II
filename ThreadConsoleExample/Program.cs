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

            Thread thread3 = new Thread(() => LongOerationWithParams2(5));
            thread3.Start();

            Thread thread4 = new Thread(new ParameterizedThreadStart(LongOerationWithParams));
            thread4.Start(10);

            thread1.Abort();

            thread1.Join();
            thread2.Join(); 

            Console.WriteLine("Koniec pracy");
            Console.ReadKey();

            if (thread1.IsAlive)
                thread1.Abort(); 
            if (thread2.IsAlive)
                thread2.Abort();
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
        static void LongOerationWithParams(object counter)
        {
            int threatId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < (int)counter; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{threatId} counter : {i}");
            }
        }
        static void LongOerationWithParams2(int counter)
        {
            int threatId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < counter; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{threatId} counter : {i}");
            }
        }
    }
}
