namespace Ebla.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto user);
        Task<Result> ValidateToken(string token);
    }
}
