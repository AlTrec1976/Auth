using Auth.DAL.Contracts.Users;
using Auth.Entities.Permissions;
using Auth.Entities.Roles;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.BLL.Contract.Admin
{
    public interface IAdminService
    {
        Task<PermissionResponse> CreatePermissionAsync(PermissionRequest permissionRequest);
        Task<RoleResponse> CreateRoleAsync(RoleRequest roleRequest);
        Task CreateRolePermissionAsync(RolePermissionRequest rolePermissionRequest);
        Task DeletePermissionAsync(PermissionResponse permissionResponse);
        Task DeleteRoleAsync(RoleResponse roleResponse);
        Task DeleteRolePermissionAsync(RolePermissionRequest rolePermissionRequest);
        Task<List<PermissionResponse>> GetAllPermissionsAsync();
        Task<List<RoleResponse>> GetAllRolesAsync();
        Task<List<PermissionResponse>> GetRolePermissionsAsync(int id);
        Task UpdatePermissionAsync(PermissionResponse permissionResponse);
        Task UpdateRoleAsync(RoleResponse roleResponse);
    }
}
