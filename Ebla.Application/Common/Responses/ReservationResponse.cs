namespace Ebla.Application.Common.Responses
{
    public record ReservationResponse(
        int Id, 
        DateTime ExpiresOn, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        BookSlimResponse Book, 
        Guid UserId);
}