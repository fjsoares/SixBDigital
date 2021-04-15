using FluentValidation;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.BookingDateTime).NotEmpty();
            RuleFor(x => x.Flexibility).NotNull();
            RuleFor(x => x.VehicleSize).NotNull();
            RuleFor(x => x.ContactNumber).NotEmpty();
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
        }
	}
}
