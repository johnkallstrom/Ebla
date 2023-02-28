namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        Task LogoutAsync();
    }
}
