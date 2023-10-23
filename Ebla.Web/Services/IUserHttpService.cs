namespace Ebla.Web.Services
{
    public interface IUserHttpService
    {
        Task LoginUserAsync(string username, string password);
    }
}
