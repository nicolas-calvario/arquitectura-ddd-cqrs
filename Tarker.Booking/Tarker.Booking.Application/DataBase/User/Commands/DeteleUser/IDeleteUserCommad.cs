namespace Tarker.Booking.Application.DataBase.User.Commands.DeteleUser
{
    public interface IDeleteUserCommad
    {
        Task<bool> Execute(int userId);
    }
}
