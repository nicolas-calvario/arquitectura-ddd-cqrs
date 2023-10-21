namespace Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPasswordQuery
{
    public interface IGetUserByUserNameAndPasswordQuery
    {
        Task<GetUserByUserNameAndPasswordQueryModel> Execute(string userName, string password);
    }
}
