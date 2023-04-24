namespace Ebla.Application.Common.Interfaces
{
    public interface ILibraryCardRepository
    {
        Task<bool> CheckValidLibraryCardExists(Guid userId);
        Task<LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
