using ApiCambioMoneda.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Interface;
using System;
using System.Collections.Generic;
using Service.Dto;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

using System.Net;
using Service.Dto.Response;
using CambioMoneda.API.Helpers;

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
        

        // GET api/<CambioMonedaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet, MapToApiVersion("1.0")]
        [SwaggerResponse(200, "With information", typeof(Response))]
        public async Task<Response> RealizarCambioMoneda([FromQuery, BindRequired] decimal monto , [FromQuery, BindRequired] string monedaOrigen , [FromQuery, BindRequired]  string  monedaDestino)
        {

            var data = await _cambioMonedaService.RealizarCambioMoneda(monto,monedaOrigen, monedaDestino);

            return new Response
            {
                Code = data.TipoCambio == -1 ? 500 : 200,
                Data = data,
                Status = data.TipoCambio == -1 ? Constantes.STATUS_FAIL : Constantes.STATUS_SUCCESS,
                Message = data.TipoCambio == -1 ? Constantes.NOT_FOUND_TYPE_CHANGE : String.Empty
            };


        }

        // POST api/<CambioMonedaController>
        [HttpPost, MapToApiVersion("1.0")]
        [SwaggerResponse(200, "With information", typeof(Response))]
        public async Task<Response> GuardarTipoCambio([FromBody, BindRequired] RequestMoneda requests)
        {
            
                var data = await _cambioMonedaService.GuardarTipoCambio(requests);

                return  new Response  { Code = data.ToString() == "OK" ? 200 : 500, Data = data,
                Status = data.ToString() == "OK" ? Constantes.STATUS_SUCCESS : Constantes.STATUS_FAIL };
            
            
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
