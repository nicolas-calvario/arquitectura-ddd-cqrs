namespace Tarker.Booking.Application.DataBase.User.Querys.GetUserById
{
    public class GetUserByIdModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
