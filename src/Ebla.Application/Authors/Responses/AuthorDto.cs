namespace Ebla.Application.Authors.Responses
{
    public record AuthorDto(
        int Id,
        string Name,
        string Description,
        DateTime Born,
        string Country,
        string Image,
        DateTime CreatedOn,
        DateTime? LastModified);
}