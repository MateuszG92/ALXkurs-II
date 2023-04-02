using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Classes
{
    public class StockDummySimulator : IEnumerable<Stock>
    {
        private Random random = new Random();
        private string[] names = { "APL", "IBM", "GOG" };
        public IEnumerator<Stock> GetEnumerator()
        {
            Console.WriteLine("Start iterator");
            for (int i = 0; i < 15; i++)
            {
                string ticker = names[random.Next(0, names.Length)];
                double val=random.Next(1,101)+random.NextDouble();
                yield return new Stock() {Name=ticker,Value=val };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
