using Domain.Models;
using Repository.Interface;
using System;
using System.Threading.Tasks;

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
    }
}
