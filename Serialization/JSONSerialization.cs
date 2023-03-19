using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    internal class JSONSerialization
    {
        public static void Create()
        {
            EmployeeJSON employeeJSON = new EmployeeJSON()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            employeeJSON.SetToken(Guid.NewGuid().ToString());
            EmployeeJSON[] employees = new EmployeeJSON[] { employeeJSON, employeeJSON, employeeJSON };

            using (FileStream fileStream = new FileStream("js.json", FileMode.Create))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(EmployeeJSON[]));
                js.WriteObject(fileStream, employees);
            }
            using (FileStream fileStream = new FileStream("js.json", FileMode.Open))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(EmployeeJSON[]));
                EmployeeJSON[] empDeserialized = js.ReadObject(fileStream) as EmployeeJSON[];
                if (empDeserialized != null)
                {
                    Console.WriteLine(empDeserialized.Length);
                    Console.ReadKey();
                }
            }
        }
    }
}
