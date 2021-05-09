using ApiCambioMoneda.Services.Dto;
using Domain.Models;
using Repository.Interface;
using Service.Dto.Response;
using Service.Interface;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Service
{
    public class CambioMonedaService : ICambioMonedaService
    {
        private readonly ICambioMonedaRepository _cambioMonedaRepository;

        public CambioMonedaService(ICambioMonedaRepository cambioMonedaRepository)
        {
            _cambioMonedaRepository = cambioMonedaRepository;
        }
        public async Task<string> GuardarTipoCambio(RequestMoneda request)
        {
            var moneda = new TipoCambioMoneda
            {
                AuditoriaFechaCreacion = DateTime.Now,
                MonedaDestino = request.MonedaDestino,
                MonedaOrigen = request.MonedaOrigen,
                FlagActivo = request.FlagActivo,
                TipoCambio = request.TipoCambio

            };
            return await _cambioMonedaRepository.GuardarTipoCambio(moneda);
        }

        public async Task<ResponseTipoCambio> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino)
        {
            var monedas = await _cambioMonedaRepository.ListaMonedas();
            var tipoCambio = await _cambioMonedaRepository.RealizarCambioMoneda(monto, monedaOrigen, monedaDestino);
            ResponseTipoCambio result = new ResponseTipoCambio
            {
                CodigoMonedaDestino = tipoCambio.MonedaDestino,
                CodigoMonedaOrigen = tipoCambio.MonedaOrigen,
                TipoCambio = tipoCambio.TipoCambio,
                Monto = monto
            };

            if (result.TipoCambio != -1)
            {
                result.MonedaDestino = monedas.First(x => x.CodigoMoneda == result.CodigoMonedaDestino).NombreMoneda;
                result.MonedaOrigen = monedas.First(x => x.CodigoMoneda == result.CodigoMonedaOrigen).NombreMoneda;
                result.MontoConTipoCambio = (monto * result.TipoCambio);
            }
            return result;

        }
    }
}
