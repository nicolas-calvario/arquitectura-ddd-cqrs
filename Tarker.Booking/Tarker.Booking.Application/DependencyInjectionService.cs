using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configurations;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomers;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeteleUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Querys.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Querys.GetUserById;
using Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPasswordQuery;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.Application.Validators.Customer;
using Tarker.Booking.Application.Validators.User;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());
            #region User
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommad, DeleteUserCommad>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion
            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddTransient<IGetCustomerByIdCommand, GetCustomerByIdCommand>();
            services.AddTransient<IGetCustomerByNumberDocument, GetCustomerByNumberDocument>();
            #endregion
            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>();
            services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();
            #endregion
            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdatePasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();            
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();
            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidation>();

            #endregion
            return services;
        }
    }
}
