namespace Ebla.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserDto> GetUserAsync(Guid userId);
        Task<UserDto> GetUserAsync(string username);
        Task<Guid> CreateUserAsync(string username, string password, string[] roles);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<bool> LoginAsync(string username, string password);
    }
}
