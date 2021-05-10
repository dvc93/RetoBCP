using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TipoCambioMoneda
    {
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }
        public DateTime? AuditoriaFechaModificacion { get; set; }

        public virtual Moneda MonedaDestinoNavigation { get; set; }
        public virtual Moneda MonedaOrigenNavigation { get; set; }
    }
}
