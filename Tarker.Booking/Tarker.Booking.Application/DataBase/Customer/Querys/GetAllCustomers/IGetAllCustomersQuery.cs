namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomers
{
    public interface IGetAllCustomersQuery
    {
        Task<List<GetAllCustomersModel>> Execute();
    }
}
