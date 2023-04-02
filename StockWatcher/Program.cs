using StockWatcher.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var observableStock=new Observable<Stock>();

            IBMStockObserver iBMStockObserver=new IBMStockObserver();
            observableStock.Subscribe(iBMStockObserver);

            AppleStockObserver appleStockObserver=new AppleStockObserver();
            observableStock.Subscribe(appleStockObserver);

            var stockSim =new StockDummySimulator();
            foreach (var item in stockSim)
            {
                Console.WriteLine($"Generator danych: {item.Name} - {item.Value}");
                observableStock.Subject=item;
            }
        }
    }
}
