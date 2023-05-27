using System.ComponentModel;

namespace WebApplicationMVC.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [DisplayName("Person name")]
        public string PersonName { get; set; }
        [DisplayName("Person Age")]
        public int PersonAge { get; set; }
    }
}
