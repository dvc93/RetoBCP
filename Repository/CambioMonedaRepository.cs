using Domain.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Repository
{
    public class CambioMonedaRepository : ICambioMonedaRepository
    {
        private readonly AppCambioDineroContext context;
        public CambioMonedaRepository ()
        {
            context = new  AppCambioDineroContext();
        }
        public async Task<string> GuardarTipoCambio(TipoCambioMoneda moneda)
        {
            string result = "OK";
            try { 
            context.TipoCambioMoneda.Add(moneda);
            context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return await Task.Run(() => result);
        }

        public async Task<List<Moneda>> ListaMonedas()
        {

            return  await Task.Run(() => context.Moneda.ToList()); 
 
        }

        public async Task<TipoCambioMoneda> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino)
        {
            var result = context.TipoCambioMoneda.Count(x => x.MonedaDestino == monedaDestino && x.MonedaOrigen == monedaOrigen) != 0 ?
            context.TipoCambioMoneda.First(x => x.MonedaDestino == monedaDestino && x.MonedaOrigen == monedaOrigen) : 
            new TipoCambioMoneda { TipoCambio = -1};
            
            return await Task.Run(() => result );

        }
    }
}
