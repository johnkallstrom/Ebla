namespace Ebla.Web.Services
{
    public interface IHttpService<T>
    {
        Task<T> GetAsync(string url);
        Task<IEnumerable<T>> GetListAsync(string url);
        Task<T> PostAsync(string url, object data);
    }
}
