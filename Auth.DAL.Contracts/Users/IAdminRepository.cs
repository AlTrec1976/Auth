using Auth.Entities.Permissions;
using Auth.Entities.Roles;

namespace Auth.DAL.Contracts.Users
{
    public interface IAdminRepository
    {
        Task<PermissionDTO> CreatePermissionAsync(PermissionDTO permissionDto);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto);
        Task CreateRolePermissionAsync(RolePermissionDTO rolePermissionDto);
        Task DeletePermisisonAsync(PermissionDTO permissionDto);
        Task DeleteRoleAsync(RoleDTO roleDto);
        Task DeleteRolePermissionAsync(RolePermissionDTO rolePermissionDto);
        Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync();
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<IEnumerable<PermissionDTO>> GetRolePermissionsAsync(int id);
        Task UpdatePermissionAsync(PermissionDTO permissionDto);
        Task UpdateRoleAsync(RoleDTO roleDto);
    }
}
