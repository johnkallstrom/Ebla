namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EblaDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(EblaDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}