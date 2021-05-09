using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Response
{
    public class Response
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
    
}
