namespace Ebla.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        Task<string> Generate(UserDto user);
    }
}
