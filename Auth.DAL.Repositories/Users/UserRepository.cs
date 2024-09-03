using Auth.DAL.Contracts.Users;
using Auth.Entities.Authz;
using Auth.Entities.Roles;
using Auth.Entities.Users;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Auth.DAL.Repositories.Users
{
    public class UserRepository(ILogger<UserRepository> logger, IConfiguration configuration)
        : BaseRepository(logger, configuration), IUserRepository
    {
        private readonly ILogger _logger = logger;

        public IAsyncEnumerable<UserDTO> GetAllUsersAsync()
        {
            var sql = "SELECT * FROM public.get_all_users()";

            return Query<UserDTO>(sql);
        }

        public async Task<UserDTO> GetByIDAsync(Guid userId)
        {
            try
            {
                var sql = "SELECT * FROM public.get_user(@id)";

                var param = new { id = userId };
                return await QuerySingleAsync<UserDTO>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске пользователя по Id");
                throw;
            }
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            try
            {
                var sql = "CALL public.update_user(@id, @login, @password, @name, @surname, @email, @phone)";

                var param = new
                {
                    id = userDTO.Id,
                    login = userDTO.Login,
                    password = userDTO.Password,
                    name = userDTO.Name,
                    surname = userDTO.Surname,
                    email = userDTO.Email,
                    phone = userDTO.Phone,
                };

                await ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении пользователя");
                throw;
            }
        }

        public async Task CreateAsync(UserDTO userDTO)
        {
            try
            {
                var sql = "CALL public.create_user(@login, @password, @name, @surname, @email, @phone)";

                var param = new
                {
                    login = userDTO.Login,
                    password = userDTO.Password,
                    name = userDTO.Name,
                    surname = userDTO.Surname,
                    email = userDTO.Email,
                    phone = userDTO.Phone,
                };

                await ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании пользователя");
                throw;
            }
        }

        public async Task DeleteAsync(Guid userId)
        {
            try
            {
                var sql = "CALL public.delete_user(@id)";

                var param = new { id = userId };
                await ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении пользователя");
                throw;
            }
        }

        public async Task<UserDTO?> GetByUserLoginAsync(string userLogin)
        {
            try
            {
                var sql = "SELECT * FROM public.check_user_login(@login)";
                var param = new { login = userLogin };
                return await QuerySingleAsync<UserDTO>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при проверки логина пользователя");
                return new UserDTO();
            }
        }

        public async Task<HashSet<PermissionEnum>> GetUserPermission(Guid userID)
        {
            try
            {
                var sql = @"SELECT * FROM public.get_permission(@id)";

                var param = new { id = userID };

                var hst = new HashSet<PermissionEnum>(await QueryAsync<PermissionEnum>(sql, param));

                return hst;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в GetUserPermission");
                throw;
            }
        }

        public async Task CreateUserRoleAsync(UserRoleDTO userRoleDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.create_user_role";
                var param = new DynamicParameters();
                param.Add("@userid", userRoleDto.Id);
                param.Add("@roleid", userRoleDto.RoleId);

                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateUserRoleAsync");
                throw;
            }
        }
        public async Task DeleteUserRoleAsync(UserRoleDTO userRoleDto)
        {
            try
            {
                var connection = GetConnection();
                var sql = "public.delete_user_role";
                var param = new DynamicParameters();
                param.Add("@userid", userRoleDto.Id);
                param.Add("@roleid", userRoleDto.RoleId);

                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteUserRoleAsync");
                throw;
            }
        }

        public async Task<IEnumerable<RoleDTO>> GetUserRolesAsync(Guid id)
        {
            try
            {
                var sql = "SELECT * FROM public.get_user_roles(@userid)";
                var param = new { userid = id };

                return await QueryAsync<RoleDTO>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выводе списка");
                throw;
            }
        }
    }
}

