namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument
{
    public interface IGetCustomerByNumberDocument
    {
        Task<GetCustomerByNumberDocumentModel> Execute(string numberDocument);
    }
}
