namespace Ebla.Application.Interfaces.Jwt
{
    public interface IJwtProvider
    {
        string GenerateToken(IApplicationUser user, string[] roles);
        Task<Guid> ValidateToken(string token);
    }
}
