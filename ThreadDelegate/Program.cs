using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating thread with delegates 
            ResultCallbackDelegate resultCallback = new ResultCallbackDelegate(ResultCallbackMethod);
            var sumHelper = new SumHelper(10, resultCallback);
            Thread thread = new Thread(sumHelper.CalculateSum);
            thread.Start();
            Console.WriteLine("Liczę...");
            thread.Join();
            Console.ReadKey(); 
        }

        private static void ResultCallbackMethod(int result)
        {
            Console.WriteLine($"Wynik operacji = {result}");
        }
    }
}
