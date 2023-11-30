namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<UserResponse> GetUserAsync(Guid userId);
        Task<UserResponse> GetUserAsync(string username);
        Task<Guid> CreateUserAsync(string username, string password, string[] rolesToAdd);
        Task UpdateUserAsync(Guid userId, string email, string[] updatedRoleList);
        Task DeleteUserAsync(Guid userId);
        Task<List<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> LoginAsync(string username, string password);
    }
}
