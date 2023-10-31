namespace Ebla.Web.Services
{
    public interface ICookieStorage
    {
        Task SetAsync(string name, string value);
        Task<string> GetAsync(string name);
    }
}
