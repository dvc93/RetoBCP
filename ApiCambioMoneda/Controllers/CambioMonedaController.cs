using ApiCambioMoneda.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCambioMoneda.Controllers
{
    [ApiVersion("1.0")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class CambioMonedaController : ControllerBase
    {
        private readonly ICambioMonedaService _cambioMonedaService;

        public CambioMonedaController (ICambioMonedaService cambioMonedaService)
        {
            _cambioMonedaService = cambioMonedaService;
        }
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
        [SwaggerResponse(200, "With information", typeof(string))]
        public async Task<IActionResult> GuardarTipoCambio([FromBody, BindRequired] RequestMoneda requests)
        {
            try
            {
                var data = await _cambioMonedaService.GuardarTipoCambio(requests);

                return StatusCode(200, data);
            }
            catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
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
