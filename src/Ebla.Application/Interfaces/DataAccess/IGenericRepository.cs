namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> GetTotalAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(int[] ids);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
