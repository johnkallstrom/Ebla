namespace Ebla.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        Task<string> GetJwtToken(UserDto user);
    }
}
