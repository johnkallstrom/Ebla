namespace Ebla.Web.Services.Interfaces
{
    public interface IGenericHttpService<T>
    {
        Task<T> GetAsync(string url);
        Task<IEnumerable<T>> GetListAsync(string url);
        Task<T> PostAsync(string url, object data);
    }
}
