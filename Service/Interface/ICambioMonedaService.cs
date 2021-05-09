using ApiCambioMoneda.Services.Dto;
using Service.Dto.Response;
using System.Threading.Tasks;

namespace Service.Interface
{
    public  interface ICambioMonedaService
    {

        Task<string> GuardarTipoCambio(RequestMoneda request);
        Task<ResponseTipoCambio> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino);
        
    }
}
