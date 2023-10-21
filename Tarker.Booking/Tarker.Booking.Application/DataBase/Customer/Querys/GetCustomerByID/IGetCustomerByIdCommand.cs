namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID
{
    public interface IGetCustomerByIdCommand
    {
        Task<GetCustomerByIdModel> Execute(int id);
    }
}
