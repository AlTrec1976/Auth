using Auth.Entities.Roles;
using Auth.Entities.Users;

namespace Auth.BLL.Contract.Users
{
    public interface IUserService
    {
        Task<string> LoginAsync(UserRequest userRequest);
        IAsyncEnumerable<UserResponse> GetAllAsync();
        Task<UserResponse?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UserRequest userRequest);
        Task CreateAsync(UserRequest userRequest);
        Task DeleteAsync(Guid id);
        Task CreateUserRoleAsync(UserRoleRequest userRoleRequest);
        Task DeleteUserRoleAsync(UserRoleRequest userRoleRequest);
        Task<List<RoleResponse>> GetAllRolesAsync(Guid id);
    }
}
