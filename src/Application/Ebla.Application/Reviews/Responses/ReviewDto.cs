namespace Ebla.Application.Reviews.Responses
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