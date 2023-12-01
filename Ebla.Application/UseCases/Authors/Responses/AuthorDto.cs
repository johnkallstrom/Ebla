namespace Ebla.Application.UseCases.Authors.Responses
{
    public record AuthorDto(
        int Id,
        string Name,
        string Description,
        DateTime Born,
        string Country,
        string ImageLink,
        string Wikipedia,
        DateTime CreatedOn,
        DateTime? LastModified);
}