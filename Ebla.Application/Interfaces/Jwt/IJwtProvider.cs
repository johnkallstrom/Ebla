namespace Ebla.Application.Interfaces.Jwt
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto user);
        Task<Guid> ValidateToken(string token);
    }
}
