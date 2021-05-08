using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Monedum
    {
        public Monedum()
        {
            TipoCambioMonedumMonedaDestinoNavigations = new HashSet<TipoCambioMonedum>();
            TipoCambioMonedumMonedaOrigenNavigations = new HashSet<TipoCambioMonedum>();
        }

        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }

        public virtual ICollection<TipoCambioMonedum> TipoCambioMonedumMonedaDestinoNavigations { get; set; }
        public virtual ICollection<TipoCambioMonedum> TipoCambioMonedumMonedaOrigenNavigations { get; set; }
    }
}
