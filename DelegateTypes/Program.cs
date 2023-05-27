using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car=new Car();
            car.MaxPrice = 20000;
            Car[] cars = new Car[]
            {
                new Car{Brand="Audi",Model="A5", Price=15000},
                new Car{Brand="BMW",Model="3", Price=25000},
                new Car{Brand="Opel",Model="Astra", Price=4000}
            };
            Predicate<Car> predicate = car.ReturnCheperCar;
            Car foundCar=Array.Find(cars, predicate);
            if (foundCar != null )
            {
                Console.WriteLine($"{foundCar.Brand}");
            }
        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public Car()
        {

        }
        public double MaxPrice { get; set; }
        public bool ReturnCheperCar(Car car)
        {
            return car.Price < MaxPrice;
        }
        public int CompareNames(Car car1, Car car2)
        {
            string s1 = $"{car1.Brand}{car1.Brand}";
            string s2 = $"{car2.Brand}{car2.Brand}";
            return s1.CompareTo(s2);
        }
    }
}

