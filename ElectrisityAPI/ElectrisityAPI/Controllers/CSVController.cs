using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectrisityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        private readonly string dataPath = @"data.csv";
        //string[]? data;
        List<string> data = new List<string>();
        IWebHostEnvironment env;

        public CSVController(IWebHostEnvironment env)
        {
            this.env = env;
        }


        [NonAction]
        public List<string> MakeData(IWebHostEnvironment env)
        {
            using (StreamReader sr = new(env.ContentRootPath + dataPath))
            {
                int i = 0;
                while (sr.Peek() > -1)
                {
                    data.Add(i + ";" + sr.ReadLine());
                    i++;
                }
            }
            return data;
        }


        // GET: api/<CSVController>
        [HttpGet]
        public List<string> GetAsync()
        {
            return MakeData(env);
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
