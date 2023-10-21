using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.DataBase;
using Tarker.Booking.Domian.Entities.Booking;
using Tarker.Booking.Domian.Entities.Customer;
using Tarker.Booking.Domian.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<UserEntity>());
            _ = new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            _ = new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }

    }
}
