namespace Ebla.Application.Common.Interfaces
{
    public interface ILibraryCardRepository
    {
        Task<LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
