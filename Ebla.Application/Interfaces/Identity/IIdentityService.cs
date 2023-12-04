namespace Ebla.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<string[]> GetUserRolesAsync(IApplicationUser user);
        Task<List<IApplicationUser>> GetAllUsersAsync();
        Task<IApplicationUser> GetApplicationUserAsync(Guid userId);
        Task<IApplicationUser> GetUserAsync(string username);
        Task<UserDto> GetUserAsync(Guid userId);
        Task<Guid> CreateUserAsync(string username, string password, string[] rolesToAdd);
        Task UpdateUserAsync(Guid userId, string email, string[] updatedRoleList);
        Task DeleteUserAsync(Guid userId);
        Task<UserDto> LoginAsync(string username, string password);
    }
}
