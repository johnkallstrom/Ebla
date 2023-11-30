namespace Ebla.Application.Common.Responses
{
    public record GenreResponse(int Id, string Name, string Description, DateTime CreatedOn, DateTime? LastModified);
}
