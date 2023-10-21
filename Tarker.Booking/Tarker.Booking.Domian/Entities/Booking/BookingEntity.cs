using Tarker.Booking.Domian.Entities.Customer;
using Tarker.Booking.Domian.Entities.User;

namespace Tarker.Booking.Domian.Entities.Booking
{
    public class BookingEntity
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public UserEntity User { get; set; } = new UserEntity();
        public CustomerEntity Customer { get; set; } = new CustomerEntity();
    }
}
