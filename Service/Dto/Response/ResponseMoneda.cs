using System;

namespace Service.Dto.Response
{
    public class ResponseMoneda
    {
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public bool? FlagActivo { get; set; }
        public DateTime? AuditoriaFechaCreacion { get; set; }
    }
}
