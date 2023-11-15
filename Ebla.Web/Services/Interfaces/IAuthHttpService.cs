namespace Ebla.Web.Services.Interfaces
{
    public interface IAuthHttpService
    {
        Task<ResultViewModel<string>> LoginUserAsync(string username, string password);
    }
}
