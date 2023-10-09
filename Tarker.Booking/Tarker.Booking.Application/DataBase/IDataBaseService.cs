using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domian.Entities.Booking;
using Tarker.Booking.Domian.Entities.Customer;
using Tarker.Booking.Domian.Entities.User;

namespace Tarker.Booking.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<BookingEntity> Booking { get; set; }
        Task<bool> SaveAsync();
    }
}
