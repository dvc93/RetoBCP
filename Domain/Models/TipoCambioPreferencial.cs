using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TipoCambioPreferencial
    {
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
    }
}
