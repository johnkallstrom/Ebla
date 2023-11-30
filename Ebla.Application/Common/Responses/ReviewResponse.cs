namespace Ebla.Application.Common.Responses
{
    public record ReviewResponse(
        int Id, 
        string Text, 
        int Rating, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        BookSlimResponse Book, 
        Guid UserId);
}