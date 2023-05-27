using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            List<User> users = new List<User>() 
            { 
                new User
                {
                    FirstName="Adam",
                    LastName="Nowak"
                },
                new User
                {
                    FirstName="Jan",
                    LastName="Kowalski"
                }
            };  
            return View(users);
        }
        [Route("/Home/Hello")]

        public string Plain()
        {
            return "Heloo world!";
        }

        public string Search1(string name, int year)
        {
            //HttpContext.Request.Query["name"] = name;
            return $"name = {name}, year = {year}";
        }

        [Route("Home/Search2/{id:int}")]
        public string Search2(int id)
        {
            return $"id={id}";
        }

        public IActionResult SessionExample()
        {
            HttpContext.Session.SetString("CurrentTime", DateTime.Now.ToString());
            HttpContext.Session.SetInt32("Counter", 1234);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}