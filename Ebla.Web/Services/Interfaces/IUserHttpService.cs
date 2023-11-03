namespace Ebla.Web.Services.Interfaces
{
    public interface IUserHttpService
    {
        Task<LoginResponse> LoginUserAsync(string username, string password);
    }
}
