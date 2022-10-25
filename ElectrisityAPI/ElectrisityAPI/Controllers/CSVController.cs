using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectrisityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        public string[] CSV { get; set; }

        // GET: api/<CSVController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return CSV;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<CSVController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CSVController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CSVController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CSVController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
