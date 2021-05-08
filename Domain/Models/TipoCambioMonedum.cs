using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TipoCambioMonedum
    {
        public int IdTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal? TipoCambio { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }
        public DateTime? AuditoriaFechaModificacion { get; set; }

        public virtual Monedum MonedaDestinoNavigation { get; set; }
        public virtual Monedum MonedaOrigenNavigation { get; set; }
    }
}
