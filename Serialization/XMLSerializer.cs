using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    internal class XMLSerialization
    {
        public static void Create()
        {
            EmployeeXML employeeXML = new EmployeeXML()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            employeeXML.SetToken(Guid.NewGuid().ToString());
            EmployeeXML[] employees = new EmployeeXML[] { employeeXML, employeeXML, employeeXML };

            using (FileStream fileStream = new FileStream("xml.xml", FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(EmployeeXML[]));
                xs.Serialize(fileStream, employees);
            }
            using (FileStream fileStream = new FileStream("xml.xml", FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(EmployeeXML[]));
                EmployeeXML[] empDeserialized = xs.Deserialize(fileStream) as EmployeeXML[];
                if (empDeserialized != null)
                {
                    Console.WriteLine(empDeserialized.Length);
                    Console.ReadKey();
                }
            }
        }
    }
}
