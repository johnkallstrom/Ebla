namespace Ebla.Application.Libraries.Responses
{
    public record LibraryDto(
        int Id,
        string Name,
        DateTime? Established,
        DateTime CreatedOn,
        DateTime? LastModified);
}