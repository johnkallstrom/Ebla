namespace Ebla.Application.UseCases.Libraries.Responses
{
    public record LibraryDto(
        int Id,
        string Name,
        DateTime? Established,
        DateTime CreatedOn,
        DateTime? LastModified,
        List<LibraryCardResponse> LibraryCards);
}