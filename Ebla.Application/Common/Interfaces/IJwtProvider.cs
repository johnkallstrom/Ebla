namespace Ebla.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto user);
        Task<bool> ValidateToken(string token);
    }
}
