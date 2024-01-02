namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IBookRepository
    {
        Task<int> GetTotalBooksAsync();
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetPagedBooksAsync(int pageNumber, int pageSize);
        Task<Book> GetBookByIdAsync(int bookId);
    }
}