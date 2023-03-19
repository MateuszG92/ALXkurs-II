using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    public class EmployeeJSON
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsManager { get; set; }
        public List<int> AccessRooms { get; set; }
        [XmlIgnore]
        public DateTime? StartAt { get; set; }
        public List<string> ExtraData { get; set; }
        private string Token; 

        public void SetToken (string token)
        {
            Token = token;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
