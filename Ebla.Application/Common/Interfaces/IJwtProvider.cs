namespace Ebla.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        Task<string> GenerateToken(UserDto user);
    }
}
