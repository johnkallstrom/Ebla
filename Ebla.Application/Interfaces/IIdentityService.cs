namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<UserDto> GetUserAsync(Guid userId);
        Task<UserDto> GetUserAsync(string username);
        Task<Guid> CreateUserAsync(string username, string password, string[] rolesToAdd);
        Task UpdateUserAsync(Guid userId, string email, string[] updatedRoleList);
        Task DeleteUserAsync(Guid userId);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> LoginAsync(string username, string password);
    }
}
