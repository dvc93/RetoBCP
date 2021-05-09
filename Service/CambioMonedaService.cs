using ApiCambioMoneda.Services.Dto;
using Domain.Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class CambioMonedaService : ICambioMonedaService
    {
        private  readonly ICambioMonedaRepository _cambioMonedaRepository;

        public CambioMonedaService (ICambioMonedaRepository cambioMonedaRepository)
        {
            _cambioMonedaRepository = cambioMonedaRepository;
        }
        public async Task<string> GuardarTipoCambio(RequestMoneda request)
        {
            var moneda = new TipoCambioMoneda {
                AuditoriaFechaCreacion = DateTime.Now,
                MonedaDestino = request.MonedaDestino,
                MonedaOrigen = request.MonedaOrigen,
                FlagActivo = request.FlagActivo,
                TipoCambio = request.TipoCambio
            
            };
            return await _cambioMonedaRepository.GuardarTipoCambio(moneda);
        }
    }
}
