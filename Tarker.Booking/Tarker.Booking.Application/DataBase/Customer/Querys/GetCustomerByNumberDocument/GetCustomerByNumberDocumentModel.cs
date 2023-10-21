namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument
{
    public class GetCustomerByNumberDocumentModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }
}
