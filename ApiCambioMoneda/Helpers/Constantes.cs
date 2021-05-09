using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CambioMoneda.API.Helpers
{
    public static class Constantes
    {
        public static readonly string STATUS_SUCCESS = "success";
        public static readonly string STATUS_ERROR = "error";
        public static readonly string STATUS_FAIL = "fail";
        public static readonly string STATUS_NOTFOUND = "notfound";
        public static readonly string NOT_FOUND_TYPE_CHANGE = "No se pudo encontrar el tipo de cambio de esta moneda.";
    }
}
