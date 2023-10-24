namespace Ebla.Web.Services
{
    public interface IUserHttpService
    {
        Task<object> LoginUserAsync(string username, string password);
    }
}
