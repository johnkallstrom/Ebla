namespace Ebla.Web.Services.Interfaces
{
    public interface IUserHttpService
    {
        Task<ResultViewModel<string>> LoginAsync(string username, string password);
        Task SignOutAsync();
        Task<List<UserViewModel>> GetAllAsync(); 
    }
}
