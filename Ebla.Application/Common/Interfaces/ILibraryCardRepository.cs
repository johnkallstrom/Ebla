namespace Ebla.Application.Common.Interfaces
{
    public interface ILibraryCardRepository
    {
        Task<bool> LibraryCardExists(Guid userId);
        Task<LibraryCard> GetLibraryCardByUserIdAsync(Guid userId);
    }
}
