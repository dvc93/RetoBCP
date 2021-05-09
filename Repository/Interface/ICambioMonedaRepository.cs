using Domain.Models;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICambioMonedaRepository
    {

        Task<string> GuardarTipoCambio(TipoCambioMoneda moneda);


    }
}
