namespace Ebla.Web.Services.Interfaces
{
    public interface IAuthorHttpService
    {
        Task<IEnumerable<AuthorViewModel>> GetAllAsync();
    }
}
