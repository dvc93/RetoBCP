namespace Service.Dto.Response
{
    public class ResponseTipoCambio
    {
        public string CodigoMonedaOrigen { get; set; }
        public string CodigoMonedaDestino { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoConTipoCambio { get; set; }
    }
}
