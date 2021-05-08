using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCambioMoneda.Controllers
{
    [ApiVersion("1.0")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class CambioMonedaController : ControllerBase
    {
        // GET: api/<CambioMonedaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CambioMonedaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CambioMonedaController>
        [HttpPost, MapToApiVersion("1.0")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CambioMonedaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CambioMonedaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
