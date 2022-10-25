using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectrisityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        // GET: api/<CSVController>
        [HttpGet]
        public async Task<string> GetAsync()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri(@"https://api.eloverblik.dk/customerapi/api/meterdata/gettimeseries/")
            };

            using HttpResponseMessage response = await client.GetAsync("2022-10-12/2022-10-13/Hour");
            return await response.Content.ReadAsStringAsync();

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
