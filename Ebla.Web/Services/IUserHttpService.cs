namespace Ebla.Web.Services
{
    public interface IUserHttpService
    {
        Task<LoginResponse> LoginUserAsync(string username, string password);
    }
}
