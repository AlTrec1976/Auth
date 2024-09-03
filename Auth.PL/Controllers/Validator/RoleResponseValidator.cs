using Auth.Entities.Roles;
using FluentValidation;

namespace Auth.PL.Controllers.Validator
{
    public class RoleResponseValidator : AbstractValidator<RoleResponse>
    {
        public RoleResponseValidator()
        {
            RuleFor(u => u.RoleName)
                .NotNull()
                .NotEmpty();
        }
    }
}
