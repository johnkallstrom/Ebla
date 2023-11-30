namespace Ebla.Application.Common.Responses
{
    public record LoanResponse(
        int Id, 
        DateTime DueDate, 
        DateTime? Returned, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        BookSlimResponse Book, 
        Guid UserId);
}