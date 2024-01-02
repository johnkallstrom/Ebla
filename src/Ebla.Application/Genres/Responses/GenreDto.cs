namespace Ebla.Application.Genres.Responses
{
    public record GenreDto(
        int Id,
        string Name,
        string Description,
        DateTime CreatedOn,
        DateTime? LastModified);
}
