namespace Ebla.Web.Services.Interfaces
{
    public interface IBookHttpService
    {
        Task<List<BookViewModel>> GetAllAsync();
    }
}
