using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelOperation pararellOperation = new ParallelOperation();
            //pararellOperation.LoopNoParallel();
            //pararellOperation.LoopParallel();
            //pararellOperation.LoopParallelForEach();
            pararellOperation.LoopParallelCancel();
            Console.ReadKey();
        }
    }
}
