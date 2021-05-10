using ApiCambioMoneda.Services.Dto;
using CambioMoneda.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Dto.Response;
using Service.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
        [SwaggerResponse(200, "With information", typeof(Response))]
        public async Task<Response> ListaMonedas()
        {

            var data = await _cambioMonedaService.ListaMonedas();

            return new Response
            {
                Code = 200,
                Data = data,
                Status = Constantes.STATUS_SUCCESS,
                
            };


        }

        // GET api/<CambioMonedaController>/5


        [HttpGet, MapToApiVersion("1.0")]
        [SwaggerResponse(200, "With information", typeof(Response))]
        public async Task<Response> RealizarCambioMoneda([FromQuery, BindRequired] decimal monto , [FromQuery, BindRequired] string monedaOrigen , [FromQuery, BindRequired]  string  monedaDestino)
        {

            var data = await _cambioMonedaService.RealizarCambioMoneda(monto,monedaOrigen, monedaDestino);
            string message = data.TipoCambio == -1 ? Constantes.NOT_FOUND_TYPE_CHANGE : String.Empty;
            message = monedaOrigen.ToUpper() == monedaDestino.ToUpper() ? Constantes.SAME_MONEY :message;
            return new Response
            {
                Code = 200,
                Data = data,
                Status = data.TipoCambio == -1 ? Constantes.STATUS_FAIL : Constantes.STATUS_SUCCESS,
                Message = message
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

      
       
    }
}
