namespace Ebla.Application.Interfaces.DataAccess
{
    public interface ILibraryRepository
    {
        Task<Library> GetLibraryByIdAsync(int libraryId);
    }
}
