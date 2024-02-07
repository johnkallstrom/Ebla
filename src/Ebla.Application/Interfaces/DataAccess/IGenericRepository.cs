namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> GetTotalAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
