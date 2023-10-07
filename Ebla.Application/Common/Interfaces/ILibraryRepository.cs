namespace Ebla.Application.Common.Interfaces
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task<Library> GetLibraryByIdAsync(int libraryId);
    }
}
