using Auth.Entities.Roles;
using FluentValidation;

namespace Auth.PL.Controllers.Validator
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator()
        {
            RuleFor(u => u.RoleName)
                .NotNull()
                .NotEmpty();
        }
    }
}
