namespace Tarker.Booking.Domian.Models
{
    public class BaseResposeModel
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
