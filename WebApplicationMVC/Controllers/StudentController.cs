using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var student = new Student()
            {
                Country = "PL"
            }; 
            return View(student);
        }
        [HttpPost]
        public IActionResult Index(Student student) 
        {
            return View(new Student());
        }
    }
}
