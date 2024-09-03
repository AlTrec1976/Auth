using Auth.Entities.Authz;

namespace Auth.BLL.Contract.Authz
{
    public interface IPermissionService
    {
        Task<HashSet<PermissionEnum>> GetPermissionsAsync(Guid userId);
    }
}
