using Auth.BLL.Contract.Admin;
using Auth.DAL.Contracts.Users;
using Auth.Entities.Permissions;
using Auth.Entities.Roles;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.BLL.Logic.Admin
{
    public class AdminService(IMapper mapper, IAdminRepository adminRepository, ILogger<AdminService> logger) : IAdminService
    {
        private readonly IAdminRepository _adminRepository = adminRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        #region Roles
        public async Task<RoleResponse> CreateRoleAsync(RoleRequest roleRequest)
        {
            var _role = _mapper.Map<Role>(roleRequest);
            _role.RoleId = default;

            var _roleDTO = _mapper.Map<RoleDTO>(_role);
            await _adminRepository.CreateRoleAsync(_roleDTO);
            var _roleResponse = _mapper.Map<RoleResponse>(_roleDTO);
            return _roleResponse;
        }
        public async Task UpdateRoleAsync(RoleResponse roleResponse)
        {
            var _role = _mapper.Map<Role>(roleResponse);
            var _roleDTO = _mapper.Map<RoleDTO>(_role);
            await _adminRepository.UpdateRoleAsync(_roleDTO);
        }
        public async Task DeleteRoleAsync(RoleResponse roleResponse)
        {
            var _role = _mapper.Map<Role>(roleResponse);
            var _roleDTO = _mapper.Map<RoleDTO>(_role);
            await _adminRepository.DeleteRoleAsync(_roleDTO);
        }

        public async Task<List<RoleResponse>> GetAllRolesAsync()
        {
            var _rolesResponse = new List<RoleResponse>();
            var _rolesDTO = await _adminRepository.GetAllRolesAsync();
            _rolesResponse = _mapper.Map<List<RoleResponse>>(_rolesDTO);
            return _rolesResponse;
        }
        #endregion

        #region Permissions
        public async Task<PermissionResponse> CreatePermissionAsync(PermissionRequest permissionRequest)
        {
            var _permission = _mapper.Map<Permission>(permissionRequest);
            _permission.PermissionId = default;

            var _permissionDTO = _mapper.Map<PermissionDTO>(_permission);
            await _adminRepository.CreatePermissionAsync(_permissionDTO);
            var _permisionResponse = _mapper.Map<PermissionResponse>(_permissionDTO);
            return _permisionResponse;
        }
        public async Task UpdatePermissionAsync(PermissionResponse permissionResponse)
        {
            var _permission = _mapper.Map<Permission>(permissionResponse);
            var _permissionDTO = _mapper.Map<PermissionDTO>(_permission);
            await _adminRepository.UpdatePermissionAsync(_permissionDTO);
        }
        public async Task DeletePermissionAsync(PermissionResponse permissionResponse)
        {
            var _permission = _mapper.Map<Permission>(permissionResponse);
            var _permissionDTO = _mapper.Map<PermissionDTO>(_permission);
            await _adminRepository.DeletePermisisonAsync(_permissionDTO);
        }

        public async Task<List<PermissionResponse>> GetAllPermissionsAsync()
        {
            var _permissionsResponse = new List<PermissionResponse>();
            var _permissionsDTO = await _adminRepository.GetAllPermissionsAsync();
            _permissionsResponse = _mapper.Map<List<PermissionResponse>>(_permissionsDTO);
            return _permissionsResponse;
        }
        #endregion

        public async Task CreateRolePermissionAsync(RolePermissionRequest rolePermissionRequest)
        {
            try
            {
                var _rolePermissionDTO = _mapper.Map<RolePermissionDTO>(rolePermissionRequest);
                await _adminRepository.CreateRolePermissionAsync(_rolePermissionDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateRolePermissionAsync");
                throw;
            }
        }
        public async Task DeleteRolePermissionAsync(RolePermissionRequest rolePermissionRequest)
        {
            try
            {
                var _rolePermissionDTO = _mapper.Map<RolePermissionDTO>(rolePermissionRequest);
                await _adminRepository.DeleteRolePermissionAsync(_rolePermissionDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteRolePermissionAsync");
                throw;
            }
        }
        public async Task<List<PermissionResponse>> GetRolePermissionsAsync(int id)
        {
            try
            {
                var _permissionsResponse = new List<PermissionResponse>();
                var _permissionsDTO = await _adminRepository.GetRolePermissionsAsync(id);
                _permissionsResponse = _mapper.Map<List<PermissionResponse>>(_permissionsDTO);
                return _permissionsResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в GetRolePermissionsAsync");
                throw;
            }
        }
    }
}
