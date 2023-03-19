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
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Serialization
{
    internal class JSONSerialization
    {
        class Rates
        {
            [JsonProperty("currency")]
            public string CurrencyName { get; set; }
            [JsonProperty("code")]
            public string CurrencyCode { get; set; }
            [JsonProperty("mid")]
            public double AverageRate { get; set; }
        }
        public static void NBP()
        {
            WebClient wb = new WebClient();
            string s = wb.DownloadString("http://api.nbp.pl/api/exchangerates/tables/A/?format=json");
            JArray ja = JArray.Parse(s);
            IList<JToken> results=ja[0]["rates"].Children().ToList();
            List<Rates> rates=new List<Rates>();
            foreach (JToken token in results)
            {
                Rates rate=token.ToObject<Rates>();
                rates.Add(rate);
            }
            foreach (var item in rates)
            {
                Console.WriteLine("______________________________");
                Console.WriteLine(item.CurrencyName);
                Console.WriteLine(item.CurrencyCode);
                Console.WriteLine(item.AverageRate);
                Console.WriteLine("______________________________");
            }
            Console.ReadKey();
        }
        
        class MyUser
        {
            public string FName { get; set; }
            public string LName { get; set; }
        }
        public static void ApplyJSON()
        {
            string s = @"{
                'fname' : 'Jan',
                'lname' : 'Kowalski',
                'manager' : false
                 }";
            MyUser user = JsonConvert.DeserializeObject<MyUser>(s, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            Console.WriteLine($"{user.FName} {user.LName}");
            Console.ReadKey();
        }
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
            //drugi sposób

            JavaScriptSerializer json = new JavaScriptSerializer();
            string s = json.Serialize(employees);
            File.WriteAllText("js2.json", s);

            EmployeeJSON[] employees2 = json.Deserialize<EmployeeJSON[]>(s);
            Console.WriteLine(employees2.Length);

            //trzeci sposób Newtonsoft.Json
            s = JsonConvert.SerializeObject(employees, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("js3.json", s);

            employees2 = JsonConvert.DeserializeObject<EmployeeJSON[]>(s);
            Console.WriteLine(employees2.Length);
            Console.ReadKey();
        }
    }
}
