using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            TipoCambioMonedumMonedaDestinoNavigations = new HashSet<TipoCambioMoneda>();
            TipoCambioMonedumMonedaOrigenNavigations = new HashSet<TipoCambioMoneda>();
        }

        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }

        public virtual ICollection<TipoCambioMoneda> TipoCambioMonedumMonedaDestinoNavigations { get; set; }
        public virtual ICollection<TipoCambioMoneda> TipoCambioMonedumMonedaOrigenNavigations { get; set; }
    }
}
