namespace Ebla.Web.Services.Interfaces
{
    public interface IBookHttpService
    {
        Task<ResultViewModel<List<BookViewModel>>> GetAllAsync();
    }
}