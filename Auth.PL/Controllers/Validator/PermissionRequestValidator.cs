using Auth.Entities.Permissions;
using FluentValidation;

namespace Auth.PL.Controllers.Validator
{
    public class PermissionRequestValidator : AbstractValidator<PermissionRequest>
    {
        public PermissionRequestValidator()
        {
            RuleFor(u => u.PermissionName)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
