using Microsoft.AspNetCore.Authorization;

namespace Auth.Entities.Authz
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string policyName;
        public PermissionRequirement(PermissionEnum[] permissions)
        {
            Permissions = permissions;
        }
        public PermissionEnum[] Permissions { get; set; } = [];
    }
}
