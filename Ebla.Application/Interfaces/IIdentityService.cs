namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<List<UserDto>> GetUsersAsync();
    }
}
