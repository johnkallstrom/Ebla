namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IBookRepository
    {
        Task<int> GetTotalBookCountAsync();
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
    }
}