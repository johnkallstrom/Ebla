namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IBookRepository
    {
        Task<int> GetTotalBooksAsync();
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
    }
}