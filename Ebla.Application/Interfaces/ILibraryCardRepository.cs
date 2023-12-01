namespace Ebla.Application.Interfaces
{
    public interface ILibraryCardRepository
    {
        Task<bool> HasValidLibraryCard(Guid userId);
        Task<LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
