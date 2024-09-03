using Auth.Entities.Users;

namespace Auth.BLL.Contract.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
