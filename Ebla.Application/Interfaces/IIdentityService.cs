namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<bool> AuthenticateAsync(string username, string password);
        Task LogoutAsync();
    }
}
