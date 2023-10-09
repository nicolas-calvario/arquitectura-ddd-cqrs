namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID
{
    public interface IGetCustomerByIdCommand
    {
        Task<GetCustomerByIdModel> Execuete(int id);
    }
}
