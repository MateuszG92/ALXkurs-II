using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverColection
{
    class Employee
    {
        public string Name { get; set; }
        public bool? IsManager { get; set; }
        public double? Salary { get; set; }
    }
    class EmployeeList : ObservableCollection<Employee>
    {
        public EmployeeList()
        {
            Add(new Employee() { Name="Jan Kowalski", IsManager=false,Salary=12345.67});
            Add(new Employee() { Name="Janusz Kowalski", IsManager = false, Salary = 123545.67 });
            Add(new Employee() { Name="Marek Kowalski", IsManager = true, Salary = 123445.67 });
            Add(new Employee() { Name="Maria Kowalska", IsManager = false, Salary = 126345.67 });
        }
    }

    internal class ObsColl
    {
    }
}
