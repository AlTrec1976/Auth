using Auth.BLL.Contract.Authz;
using Auth.DAL.Contracts.Users;
using Auth.Entities.Authz;
using Microsoft.Extensions.Logging;

namespace Auth.BLL.Logic.Authz
{
    public class PermissionService(IUserRepository userRepository, ILogger<PermissionService> logger) : IPermissionService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILogger _logger = logger;

        public async Task<HashSet<PermissionEnum>> GetPermissionsAsync(Guid userId)
        {
            try
            {
                return await userRepository.GetUserPermission(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в ");
                throw;
            }
        }
    }
}
