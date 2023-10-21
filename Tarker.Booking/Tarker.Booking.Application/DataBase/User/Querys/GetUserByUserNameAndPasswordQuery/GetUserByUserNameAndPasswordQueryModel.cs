namespace Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPasswordQuery
{
    public class GetUserByUserNameAndPasswordQueryModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
