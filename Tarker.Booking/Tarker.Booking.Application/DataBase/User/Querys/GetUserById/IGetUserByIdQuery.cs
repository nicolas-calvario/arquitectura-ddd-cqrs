namespace Tarker.Booking.Application.DataBase.User.Querys.GetUserById
{
    public interface IGetUserByIdQuery
    {
        Task<GetUserByIdModel> Execute(int userId);
    }
}
