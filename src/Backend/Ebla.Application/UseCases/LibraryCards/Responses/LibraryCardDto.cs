namespace Ebla.Application.UseCases.LibraryCards.Responses
{
    public record LibraryCardDto(
        int Id,
        int PIN,
        DateTime ExpiresOn,
        DateTime CreatedOn,
        DateTime? LastModified,
        Guid UserId);
}