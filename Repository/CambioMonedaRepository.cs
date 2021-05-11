using Domain.Models;
using Microsoft.Extensions.Options;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CambioMonedaRepository : ICambioMonedaRepository
    {
        private readonly AppCambioDineroContext _context;
        private readonly Config _config;
        public CambioMonedaRepository ( AppCambioDineroContext context ,  IOptions<Config> config)
        {
            _context = context;
            _config = config.Value;

        }
        public async Task<string> GuardarTipoCambio(TipoCambioMoneda moneda , bool isModify)
        {
            string result = "OK";
            try {

                if (isModify)
                {
                    _context.Entry(moneda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    _context.TipoCambioMoneda.Add(moneda);
                }
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return await Task.Run(() => result);
        }

        public async Task<List<Moneda>> ListaMonedas()
        {

            return  await Task.Run(() => _context.Moneda.ToList()); 
 
        }

        public async Task<TipoCambioMoneda> ObtenerIdTipoCambio(string monedaOrigen, string monedaDestino)
        {
            var  result = new TipoCambioMoneda(); 
            var listTipoCampio = _context.TipoCambioMoneda.ToList();

            if (listTipoCampio.Any( x=> x.MonedaOrigen == monedaOrigen && x.MonedaDestino == monedaDestino))
            {
                result = listTipoCampio.First(x => x.MonedaOrigen == monedaOrigen && x.MonedaDestino == monedaDestino);
            }
            return await Task.Run(() => result);

        }

        

        public async Task<TipoCambioMoneda> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino)
        {
            var result = _context.TipoCambioMoneda.Count(x => x.MonedaDestino == monedaDestino && x.MonedaOrigen == monedaOrigen) != 0 ?
            _context.TipoCambioMoneda.First(x => x.MonedaDestino == monedaDestino && x.MonedaOrigen == monedaOrigen) : 
            new TipoCambioMoneda { TipoCambio = -1};
            
            return await Task.Run(() => result );

        }

        public async Task<bool> VerficarClientePreferencial(int idCliente)
        {
            var isPref = _context.Clientes.First(x => x.IdCliente == idCliente).ClientePreferencial.Value ;
             return await Task.Run(() => isPref); 
        }

        public async Task<decimal> ObtenerTipoCambioPreferencial(string monedaOrigen, string monedaDestino)
        {
            var  tipoCambioPref = _context.TipoCambioPreferencials.ToList().First(x => x.MonedaDestino == monedaDestino && x.MonedaOrigen == monedaOrigen).TipoCambio;
            return await Task.Run(() => tipoCambioPref);
        }
    }
}
