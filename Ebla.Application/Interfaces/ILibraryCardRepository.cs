namespace Ebla.Application.Interfaces
{
    public interface ILibraryCardRepository
    {
        Task<bool> HasValidLibraryCard(Guid userId);
        Task<Domain.Entities.LibraryCard> GetLibraryCardAsync(Guid userId);
    }
}
