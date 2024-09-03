using Auth.Entities.Permissions;

namespace Auth.Entities.Roles
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
