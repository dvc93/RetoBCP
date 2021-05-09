using System;

namespace ApiCambioMoneda.Services.Dto
{
    public class RequestMoneda
    {
        public int IdTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }
        public DateTime? AuditoriaFechaModificacion { get; set; }
    }
}
