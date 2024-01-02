namespace Ebla.Persistence.Repositories
{
    public class BookRepository : IBookRepository

    {
        private readonly EblaDbContext _context;

        public BookRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .Include(x => x.Reservations)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == bookId);

            return book;
        }

        public async Task<IEnumerable<Book>> GetPagedBooksAsync(int pageNumber, int pageSize)
        {
            var books = await _context.Books
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .ToListAsync();

            return books;
        }

        public async Task<int> GetTotalBooksAsync()
        {
            var books = await _context.Books.ToListAsync();

            return books.Count();
        }
    }
}