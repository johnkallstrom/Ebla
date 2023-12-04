namespace Ebla.Application.Interfaces.Data
{
    public interface ILibraryCardRepository
    {
        Task<bool> HasValidLibraryCard(Guid userId);
        Task<LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
