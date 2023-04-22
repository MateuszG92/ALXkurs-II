using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id) {  return "value"+id; }

        [HttpPost]
       // public string Post(string value) 
        public string Post([FromBody] string value) 
        {
            return $"POST: {value}";
        }   
    }
}
