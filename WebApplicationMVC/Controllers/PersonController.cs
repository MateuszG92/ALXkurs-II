using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        public static IList<Person> peopleList = new List<Person>()
        {
            new Person{PersonId=1,PersonName="Jan Kowalski",PersonAge=33},
            new Person{PersonId=3,PersonName="Jacek Cygan",PersonAge=21},
            new Person{PersonId=2,PersonName="Gość Naziwsko",PersonAge=48}
        };
        public IActionResult Index()
        {
            return View(peopleList.OrderBy(x => x.PersonId).ToList());
        }
        public IActionResult Edit(int id)
        {
            var person = peopleList.Where(x=>x.PersonId==id).FirstOrDefault();
            if(person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var p = peopleList.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            peopleList.Remove(p);
            peopleList.Add(person);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var p = peopleList.Where(x => x.PersonId == id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            peopleList.Remove(p);
            return RedirectToAction("Index");
        }
    }
}
