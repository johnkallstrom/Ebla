namespace Ebla.Application.Interfaces.DataAccess
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task<Library> GetLibraryByIdAsync(int libraryId);
    }
}
