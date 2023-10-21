using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    internal class UpdatePasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(10);
        }
    }
}
