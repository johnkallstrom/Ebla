namespace Ebla.Application.Interfaces.DataAccess
{
    public interface ILibraryCardRepository
    {
        Task<bool> HasValidLibraryCard(Guid userId);
        Task<LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
