namespace Ebla.Web.Services.Interfaces
{
    public interface IUserHttpService
    {
        Task<LoginResultViewModel> LoginUserAsync(string username, string password);
    }
}
