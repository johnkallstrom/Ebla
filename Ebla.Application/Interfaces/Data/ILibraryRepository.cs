namespace Ebla.Application.Interfaces.Data
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task<Library> GetLibraryByIdAsync(int libraryId);
    }
}
