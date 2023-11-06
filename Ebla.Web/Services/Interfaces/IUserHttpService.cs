namespace Ebla.Web.Services.Interfaces
{
    public interface IUserHttpService
    {
        Task<ResultViewModel<string>> LoginUserAsync(string username, string password);
    }
}
