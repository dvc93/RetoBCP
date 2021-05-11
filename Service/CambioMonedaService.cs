using ApiCambioMoneda.Services.Dto;
using Domain.Models;
using Repository.Interface;
using Service.Dto.Response;
using Service.Interface;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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
            var moneda = await _cambioMonedaRepository.ObtenerIdTipoCambio(request.MonedaOrigen, request.MonedaDestino);
            bool isModify = false;
            if ( string.IsNullOrEmpty(moneda.MonedaDestino))
            {
               
                moneda.AuditoriaFechaCreacion = DateTime.Now;
                moneda.MonedaDestino = request.MonedaDestino;
                moneda.MonedaOrigen = request.MonedaOrigen;
                moneda.FlagActivo = request.FlagActivo;
            }
            else
            {
                moneda.AuditoriaFechaModificacion = DateTime.Now;
                isModify = true;

            }
            moneda.TipoCambio = request.TipoCambio;

            return await _cambioMonedaRepository.GuardarTipoCambio(moneda, isModify);
        }

        public async Task<ResponseTipoCambio> RealizarCambioMoneda(decimal monto, string monedaOrigen, string monedaDestino , int idCliente)
        {
            var monedas = await _cambioMonedaRepository.ListaMonedas();
            var IsPref = await _cambioMonedaRepository.VerficarClientePreferencial(idCliente);
            var tipoCambioPref = await _cambioMonedaRepository.ObtenerTipoCambioPreferencial(monedaOrigen, monedaDestino);
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
                var tipoCambioFinal = IsPref ? tipoCambioPref : result.TipoCambio;
                result.MontoConTipoCambio = (   monto * tipoCambioFinal);
            }

            result.TipoCambio = IsPref ? tipoCambioPref : result.TipoCambio;
            return result;

        }

        public async Task<IEnumerable<ResponseMoneda>> ListaMonedas()
        {
            var listaMonedas = new List<ResponseMoneda>();
            var monedas = await _cambioMonedaRepository.ListaMonedas();
            monedas.ForEach(x =>
            listaMonedas.Add( new ResponseMoneda { 
                CodigoMoneda = x.CodigoMoneda,
                AuditoriaFechaCreacion = x.AuditoriaFechaCreacion,
                FlagActivo = x.FlagActivo,
                NombreMoneda = x.NombreMoneda
            
            })

            );

            return listaMonedas;
        }
    }
}
