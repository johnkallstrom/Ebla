namespace Ebla.Application.Common.Responses
{
    public record LibraryCardResponse(
        int Id, 
        int PIN, 
        DateTime ExpiresOn, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        Guid UserId);
}