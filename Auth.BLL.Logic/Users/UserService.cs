using Auth.BLL.Contract.Auth;
using Auth.BLL.Contract.Users;
using Auth.DAL.Contracts.Users;
using Auth.Entities.Roles;
using Auth.Entities.Users;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.BLL.Logic.Users
{
    public class UserService(IMapper mapper, IUserRepository userRepository,
        IPasswordHasher passwordHasher, IJwtProvider jwtProvider, ILogger<UserService> logger) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly ILogger _logger = logger;

        public async IAsyncEnumerable<UserResponse> GetAllAsync()
        {
            await foreach (var item in _userRepository.GetAllUsersAsync())
            {
                yield return _mapper.Map<UserResponse>(item);
            }
        }

        public async Task<UserResponse?> GetByIdAsync(Guid id)
        {
            try
            {
                var users = new User();
                var usersResponse = new UserResponse();

                var usersDTO = await _userRepository.GetByIDAsync(id);

                users = _mapper.Map<User>(usersDTO);
                usersResponse = _mapper.Map<UserResponse>(users);

                return usersResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в GetByIdAsync");
                throw;
            }
        }

        //Регистрация пользователя
        public async Task<string> LoginAsync(UserRequest userRequest)
        {
            try
            {
                var user = new User();
                var userDTO = await _userRepository.GetByUserLoginAsync(userRequest.Login);
                if (userDTO is null)
                {
                    return "Нет записи";
                }

                user = _mapper.Map<User>(userDTO);

                //проверка пароля
                var result = _passwordHasher.Verify(userRequest.Password, user.Password);
                if (result is false)
                {
                    throw new Exception("Пароль введен не верно");
                }

                var token = _jwtProvider.GenerateToken(user);

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в LoginAsync");
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, UserRequest userRequest)
        {
            try
            {
                var _hashedPassword = _passwordHasher.Generate(userRequest.Password);
                var _user = new User();
                var _userDTO = new UserDTO();

                _user = _mapper.Map<User>(userRequest);
                _user.Id = id;
                _user.Password = _hashedPassword;

                _userDTO = _mapper.Map<UserDTO>(_user);

                await _userRepository.UpdateAsync(_userDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в UpdateAsync");
                throw;
            }
        }

        public async Task CreateAsync(UserRequest userRequest)
        {
            try
            {
                var isExistLogin = await _userRepository.GetByUserLoginAsync(userRequest.Login);

                if (isExistLogin?.Login is not null)
                {
                    throw new Exception("Данный логин пользователя уже есть в БД");
                }

                var _hashedPassword = _passwordHasher.Generate(userRequest.Password);
                var _user = new User();
                var _userDTO = new UserDTO();

                _user = _mapper.Map<User>(userRequest);
                _user.Password = _hashedPassword;
                _userDTO = _mapper.Map<UserDTO>(_user);

                await _userRepository.CreateAsync(_userDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateAsync");
                throw;
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteAsync");
                throw;
            }
        }
        public async Task CreateUserRoleAsync(UserRoleRequest userRoleRequest)
        {
            try
            {
                var _userRoleDTO = _mapper.Map<UserRoleDTO>(userRoleRequest);
                await _userRepository.CreateUserRoleAsync(_userRoleDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateUserRoleAsync");
                throw;
            }
        }
        public async Task DeleteUserRoleAsync(UserRoleRequest userRoleRequest)
        {
            try
            {
                var _userRoleDTO = _mapper.Map<UserRoleDTO>(userRoleRequest);
                await _userRepository.DeleteUserRoleAsync(_userRoleDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteUserRoleAsync");
                throw;
            }
        }

        public async Task<List<RoleResponse>> GetAllRolesAsync(Guid id)
        {
            try
            {
                var _rolesResponse = new List<RoleResponse>();
                var _rolesDTO = await _userRepository.GetUserRolesAsync(id);
                _rolesResponse = _mapper.Map<List<RoleResponse>>(_rolesDTO);

                return _rolesResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в GetAllRolesAsync");
                throw;
            }
        }
    }
}
