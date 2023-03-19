using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    internal class SoapSerializer
    {
        public static void Create()
        {
            EmployeeSoap employeeSoap = new EmployeeSoap()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            employeeSoap.SetToken(Guid.NewGuid().ToString());
            EmployeeSoap[] employees = new EmployeeSoap[] { employeeSoap, employeeSoap, employeeSoap };

            using (FileStream fileStream=new FileStream("soap.xml",FileMode.Create))
            {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fileStream,employees);
            }
            using (FileStream fileStream = new FileStream("soap.xml", FileMode.Open))
            {
                SoapFormatter sf = new SoapFormatter();
                EmployeeSoap[] empDeserialized= sf.Deserialize(fileStream) as EmployeeSoap[];
                if (empDeserialized != null)
                {
                    Console.WriteLine(empDeserialized.Length);
                    Console.ReadKey();
                }
            }
        }
    }
}
