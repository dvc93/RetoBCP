using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Usuario
    {
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public string Clave { get; set; }
        public string Token { get; set; }
    }
}
