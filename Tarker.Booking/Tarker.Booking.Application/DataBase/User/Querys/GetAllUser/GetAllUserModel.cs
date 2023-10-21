namespace Tarker.Booking.Application.DataBase.User.Querys.GetAllUser
{
    public class GetAllUserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
