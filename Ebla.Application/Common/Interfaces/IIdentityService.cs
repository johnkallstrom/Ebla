namespace Ebla.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserDto> GetUserAsync(Guid userId);
        Task<UserDto> GetUserAsync(string username);
        Task CreateUserAsync(string username, string password);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
