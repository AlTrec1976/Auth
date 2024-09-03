using Auth.Entities.Authz;
using Auth.Entities.Roles;
using Auth.Entities.Users;

namespace Auth.DAL.Contracts.Users
{
    public interface IUserRepository
    {
        IAsyncEnumerable<UserDTO> GetAllUsersAsync();
        Task<UserDTO> GetByIDAsync(Guid id);
        Task UpdateAsync(UserDTO UserDto);
        Task CreateAsync(UserDTO UserDto);
        Task DeleteAsync(Guid id);
        Task<UserDTO?> GetByUserLoginAsync(string userLogin);
        Task<HashSet<PermissionEnum>> GetUserPermission(Guid userID);
        Task CreateUserRoleAsync(UserRoleDTO UserRoleDto);
        Task DeleteUserRoleAsync(UserRoleDTO UserRoleDto);
        Task<IEnumerable<RoleDTO>> GetUserRolesAsync(Guid id);
    }
}
