namespace Auth.Entities.Auth
{
    public class JwtOptions : IJwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresHours { get; set; } = default;
    }
}
