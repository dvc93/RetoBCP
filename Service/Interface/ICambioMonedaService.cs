using ApiCambioMoneda.Services.Dto;
using System.Threading.Tasks;

namespace Service.Interface
{
    public  interface ICambioMonedaService
    {

        Task<string> GuardarTipoCambio(RequestMoneda request);
    }
}
