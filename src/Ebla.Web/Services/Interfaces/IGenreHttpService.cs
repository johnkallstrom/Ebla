namespace Ebla.Web.Services.Interfaces
{
    public interface IGenreHttpService
    {
        Task<IEnumerable<GenreViewModel>> GetAllAsync();
    }
}
