using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Classes
{
    public class AppleStockObserver : IObserver<Stock>
    {
        public void Update(Stock data)
        {
            if (data.Name.Equals("APL")&&data.Value>=30)
            {
                Console.WriteLine("Akcje Apple powyżej 30");
            }
        }
    }
    public class IBMStockObserver : IObserver<Stock>
    {
        public void Update(Stock data)
        {
            if (data.Name.Equals("IBM") && data.Value >= 20)
            {
                Console.WriteLine("Akcje Apple powyżej 20");
            }
        }
    }
}
