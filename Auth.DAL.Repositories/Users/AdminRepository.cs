using Auth.DAL.Contracts.Users;
using Auth.Entities.Permissions;
using Auth.Entities.Roles;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Auth.DAL.Repositories.Users
{
    public class AdminRepository(ILogger<AdminRepository> logger, IConfiguration configuration) : BaseRepository(logger, configuration), IAdminRepository
    {
        private readonly ILogger _logger = logger;

        #region Roles
        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.create_role";
                var param = new DynamicParameters();
                param.Add("@rolename", roleDto.RoleName);
                param.Add("@roleid", dbType: DbType.Int32,
                                      direction: ParameterDirection.Output);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
                roleDto.RoleId = param.Get<int>("@roleid");
                return roleDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateRoleAsync");
                throw;
            }
        }

        public async Task UpdateRoleAsync(RoleDTO roleDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.update_role";
                var param = new DynamicParameters();
                param.Add("@roleid", roleDto.RoleId);
                param.Add("@rolename", roleDto.RoleName);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в UpdateRoleAsync");
                throw;
            }
        }

        public async Task DeleteRoleAsync(RoleDTO roleDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.delete_role";
                var param = new DynamicParameters();
                param.Add("@wroleid", roleDto.RoleId);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteRoleAsync");
                throw;
            }
        }
        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var sql = "SELECT * FROM public.get_all_roles()";

                return await QueryAsync<RoleDTO>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выводе списка");
                throw;
            }
        }
        #endregion

        #region Permissions
        public async Task<PermissionDTO> CreatePermissionAsync(PermissionDTO permissionDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.create_permission";
                var param = new DynamicParameters();
                param.Add("@permissionname", permissionDto.PermissionName);
                param.Add("@permissionid", dbType: DbType.Int32,
                                      direction: ParameterDirection.Output);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
                permissionDto.PermissionId = param.Get<int>("@permissionid");
                return permissionDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreatePermissionAsync");
                throw;
            }
        }

        public async Task UpdatePermissionAsync(PermissionDTO permissionDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.update_permission";
                var param = new DynamicParameters();
                param.Add("@permissionid", permissionDto.PermissionId);
                param.Add("@permissionname", permissionDto.PermissionName);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в UpdatePermissionAsync");
                throw;
            }
        }

        public async Task DeletePermisisonAsync(PermissionDTO permissionDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.delete_permission";
                var param = new DynamicParameters();
                param.Add("@permission_id", permissionDto.PermissionId);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeletePermisisonAsync");
                throw;
            }
        }
        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            try
            {
                var sql = "SELECT * FROM get_all_permissions()";

                return await QueryAsync<PermissionDTO>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выводе списка");
                throw;
            }
        }
        #endregion

        public async Task CreateRolePermissionAsync(RolePermissionDTO rolePermissionDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.create_role_permission";
                var param = new DynamicParameters();
                param.Add("@role_id", rolePermissionDto.RoleId);
                param.Add("@permission_id", rolePermissionDto.PermissionId);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateRolePermissionAsync");
                throw;
            }
        }
        public async Task DeleteRolePermissionAsync(RolePermissionDTO rolePermissionDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.delete_role_permission";
                var param = new DynamicParameters();
                param.Add("@role_id", rolePermissionDto.RoleId);
                param.Add("@permission_id", rolePermissionDto.PermissionId);
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteRolePermissionAsync");
                throw;
            }
        }

        public async Task<IEnumerable<PermissionDTO>> GetRolePermissionsAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM get_role_permissions(@wrole_id)";
                var param = new { wrole_id = id };

                return await QueryAsync<PermissionDTO>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выводе списка");
                throw;
            }
        }
    }
}
