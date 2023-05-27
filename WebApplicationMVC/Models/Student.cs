using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Student
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; } 

        public List<SelectListItem> Countries { get;}=new List<SelectListItem>()
        {
            new SelectListItem{Value="PL", Text="Polska"},
            new SelectListItem{Value="DE", Text="Niemcy"},
        };
        
    }
}
