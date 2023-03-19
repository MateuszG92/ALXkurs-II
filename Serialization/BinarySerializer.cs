using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    internal class BinarySerializer
    {
        public static void Create()
        {
            Employee employee = new Employee()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                AccessRooms = new List<int>() { 2, 3, 4 },
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            employee.SetToken(Guid.NewGuid().ToString());

            using (FileStream fileStream=new FileStream("dump.bin",FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream,employee);
            }
            using (FileStream fileStream = new FileStream("dump.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Employee empDeserialized= bf.Deserialize(fileStream) as Employee;
                if (empDeserialized != null)
                {
                    Console.WriteLine(empDeserialized);
                    Console.ReadKey();
                }
            }
        }
    }
}
