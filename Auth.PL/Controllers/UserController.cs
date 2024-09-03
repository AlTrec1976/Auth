using Auth.BLL.Contract.Users;
using Auth.BLL.Logic.Authz;
using Auth.Entities.Authz;
using Auth.Entities.Roles;
using Auth.Entities.Users;
using Auth.PL.Controllers.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Auth.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ILogger _logger = logger;

        /// <summary>
        /// Вход пользователя в систему
        /// </summary>
        /// <remarks>
        /// Пример по документации контроллеров
        /// </remarks>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Возваращает cookie с токеном</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(UserRequest), (int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogin userLogin)
        {
            try
            {
                var _userRequest = new UserRequest();
                _userRequest.Login = userLogin.Login;
                _userRequest.Password = userLogin.Password;
                //создать токен
                var _token = await _userService.LoginAsync(_userRequest);

                return Ok(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в LoginAsync");
                throw;
            }
        }

        // GET: api/<UserController>
        /// <summary>
        /// Запросить всех пользователей
        /// </summary>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.read])]
        [HttpGet]
        public IAsyncEnumerable<UserResponse> GetAsync()
        {
            return _userService.GetAllAsync();
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Запрос пользователя по ID
        /// </summary>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.read])]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetAsync(Guid id)
        {
            try
            {
                var _userResponse = await _userService.GetByIdAsync(id);

                if (_userResponse is null)
                    return NotFound();

                return Ok(_userResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в GetAsync по id");
                throw;
            }
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Изменение данных пользователя
        /// </summary>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.update])]
        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, [FromBody] UserRequest userRequest)
        {
            try
            {
                var validator = new UserValidator();

                var validationResult = validator.Validate(userRequest);

                if (!validationResult.IsValid)
                {
                    var error = string.Empty;

                    foreach (var item in validationResult.Errors)
                    {
                        error += $"{item} \n";
                    }

                    throw new Exception(error);
                }

                await _userService.UpdateAsync(id, userRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в UpdateAsync");
                throw;
            }
        }
        // POST api/<UserController>
        /// <summary>
        /// Создание пользователя
        /// </summary>
        //[Authorize]
        //[HasPermission([PermissionEnum.admin, PermissionEnum.create])]
        [AllowAnonymous]
        [HttpPost]
        public async Task CreateAsync([FromBody] UserRequest userRequest)
        {
            try
            {
                var validator = new UserValidator();
                var validationResult = validator.Validate(userRequest);

                if (!validationResult.IsValid)
                {
                    var error = string.Empty;

                    foreach (var item in validationResult.Errors)
                    {
                        error += $"{item} \n";
                    }

                    throw new Exception(error);
                }

                await _userService.CreateAsync(userRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в CreateAsync");
                throw;
            }
        }

        // DELETE api/<UserController>/5
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.delete])]
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в DeleteAsync");
                throw;
            }
        }

        /// <summary>
        /// Назначение пользователю роли
        /// </summary>
        /// <param name="userRoleRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.create])]
        [HttpPost("roles")]
        public async Task CreateRolePermissionAsync([FromBody] UserRoleRequest userRoleRequest)
        {
            await _userService.CreateUserRoleAsync(userRoleRequest);
        }

        /// <summary>
        /// Удаление роли у пользователя
        /// </summary>
        /// <param name="userRoleRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.delete])]
        [HttpDelete("roles")]
        public async Task DeleteRolePermissionAsync([FromBody] UserRoleRequest userRoleRequest)
        {
            await _userService.DeleteUserRoleAsync(userRoleRequest);
        }

        /// <summary>
        /// Возвращает все роли назначенные пользователю
        /// </summary>
        /// <param name="id">Ид пользователя</param>
        /// <returns></returns>
        [Authorize]
        [HasPermission([PermissionEnum.admin, PermissionEnum.read])]
        [HttpGet("roles")]
        public async Task<List<RoleResponse>> GetUserRolesAsync(Guid id)
        {
            return await _userService.GetAllRolesAsync(id);
        }
    }
}
