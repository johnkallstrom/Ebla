namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
    }
}
