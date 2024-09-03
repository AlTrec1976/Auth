using Auth.Entities.Permissions;
using FluentValidation;

namespace Auth.PL.Controllers.Validator
{
    public class PermissionResponseValidator : AbstractValidator<PermissionResponse>
    {
        public PermissionResponseValidator()
        {
            RuleFor(u => u.PermissionName)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
