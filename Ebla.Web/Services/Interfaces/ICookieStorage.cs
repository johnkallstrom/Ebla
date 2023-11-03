namespace Ebla.Web.Services.Interfaces
{
    public interface ICookieStorage
    {
        Task InitializeAsync();
        Task SetAsync(string name, string value);
        Task<string> GetAsync();
    }
}
