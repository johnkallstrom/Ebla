namespace Ebla.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserResponse user);
        Task<Guid> ValidateToken(string token);
    }
}
