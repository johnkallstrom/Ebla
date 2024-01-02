namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
    }
}
