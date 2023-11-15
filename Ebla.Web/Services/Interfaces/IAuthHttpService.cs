namespace Ebla.Web.Services.Interfaces
{
    public interface IAuthHttpService
    {
        Task<ResultViewModel<string>> LoginAsync(string username, string password);
        Task SignOutAsync();
    }
}
