using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Documento { get; set; }
        public bool? ClientePreferencial { get; set; }
    }
}
