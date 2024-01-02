namespace Ebla.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<int> GetTotalUsersAsync();
        Task<string[]> GetUserRolesAsync(IApplicationUser user);
        Task<List<IApplicationUser>> GetAllUsersAsync();
        Task<IApplicationUser> GetUserAsync(string username);
        Task<IApplicationUser> GetUserAsync(Guid userId);
        Task<bool> LoginAsync(string username, string password);
        Task<Guid> CreateUserAsync(string username, string password, string[] rolesToAdd);
        Task UpdateUserAsync(Guid userId, string email, string[] updatedRoleList);
        Task DeleteUserAsync(Guid userId);
    }
}
