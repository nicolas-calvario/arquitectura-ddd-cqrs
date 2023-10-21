using FluentValidation;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidation: AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.Code).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.Type).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}
