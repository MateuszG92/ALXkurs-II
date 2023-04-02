using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverColection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeList employees = new EmployeeList();
            employees.CollectionChanged += Employees_CollectionChanged;
            employees.Add(new Employee() { Name = "Marian Witkowski" });
            employees.Insert(0, new Employee() { Name = "Mateusz Cudowny"});
            employees.RemoveAt(1);
            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }  
        }

        private static void Employees_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Operacja: {e.Action}");
        }
    }
}
