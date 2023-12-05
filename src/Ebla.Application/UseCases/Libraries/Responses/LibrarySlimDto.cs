namespace Ebla.Application.UseCases.Libraries.Responses
{
    public record LibrarySlimDto(
        int Id,
        string Name,
        DateTime? Established);
}