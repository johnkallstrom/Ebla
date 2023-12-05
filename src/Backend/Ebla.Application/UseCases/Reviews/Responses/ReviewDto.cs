namespace Ebla.Application.UseCases.Reviews.Responses
{
    public record ReviewDto(
        int Id,
        string Text,
        int Rating,
        DateTime CreatedOn,
        DateTime? LastModified,
        BookSlimDto Book,
        Guid UserId);
}