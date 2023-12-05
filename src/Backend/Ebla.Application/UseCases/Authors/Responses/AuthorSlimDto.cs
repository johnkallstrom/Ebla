namespace Ebla.Application.UseCases.Authors.Responses
{
    public record AuthorSlimDto(
        int Id,
        string Name,
        DateTime Born,
        string Country,
        string ImageLink);
}
