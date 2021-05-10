using Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICambioMonedaRepository
    {

        Task<string> GuardarTipoCambio(TipoCambioMoneda moneda , bool isModify);
        Task<TipoCambioMoneda> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino);
        Task<List<Moneda>> ListaMonedas();
        Task<TipoCambioMoneda> ObtenerIdTipoCambio(string monedaOrigen , string monedaDestino);

    }
}
