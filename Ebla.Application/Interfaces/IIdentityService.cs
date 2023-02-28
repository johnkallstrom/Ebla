namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task CreateUserAsync(string username, string password);
        Task<List<UserDto>> GetUsersAsync();
    }
}
