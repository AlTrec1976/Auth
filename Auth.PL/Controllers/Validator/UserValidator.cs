using Auth.Entities.Users;
using FluentValidation;

namespace Auth.PL.Controllers.Validator
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(u => u.Login)
                .NotNull()
                .NotEmpty()
                .Length(3, 20);

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .Length(5, 128);

            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);

            RuleFor(u => u.Surname)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .Length(4, 50);

            RuleFor(u => u.Phone)
                .NotNull()
                .NotEmpty()
                .Length(10, 15);
        }
    }
}
