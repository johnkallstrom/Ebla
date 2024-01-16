namespace Ebla.Web.Services.Interfaces
{
    public interface ILibraryHttpService
    {
        Task<IEnumerable<LibraryViewModel>> GetAllAsync();
    }
}
