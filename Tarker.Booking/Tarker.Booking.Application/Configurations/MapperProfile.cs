using AutoMapper;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomers;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Querys.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Querys.GetUserById;
using Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPasswordQuery;
using Tarker.Booking.Domian.Entities.Booking;
using Tarker.Booking.Domian.Entities.Customer;
using Tarker.Booking.Domian.Entities.User;

namespace Tarker.Booking.Application.Configurations
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordQueryModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomersModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByNumberDocumentModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            #endregion
        }
    }
}
