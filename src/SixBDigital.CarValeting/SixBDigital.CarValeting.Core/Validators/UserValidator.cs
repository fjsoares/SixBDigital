using FluentValidation;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
