using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeProblem
{
    internal class LockPerformance
    {
        private List<TestClass> dataList = new List<TestClass>(1000);
        const int maxValue = 1000000;
        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
        private int testValue;

        public double ClassicLock()
        {
            dataList.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < maxValue; i++)
            {
                lock (this)
                {
                    TestClass testClass = new TestClass();
                    testClass.x = 123.45;
                    dataList.Add(testClass);
                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
        public double Semaphore()
        {
            dataList.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < maxValue; i++)
            {
                semaphoreSlim.Wait();
                TestClass testClass = new TestClass();
                testClass.x = 123.45;
                dataList.Add(testClass);
                semaphoreSlim.Release();
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
        public double MonitorLock()
        {
            dataList.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < maxValue; i++)
            {
                TestClass testClass = new TestClass();
                testClass.x = 123.45;
                Monitor.Enter(dataList);
                dataList.Add(testClass);
                Monitor.Exit(dataList);
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
        public void InterlockedTest()
        {
            Interlocked.Increment(ref testValue);
        }
    }
}
