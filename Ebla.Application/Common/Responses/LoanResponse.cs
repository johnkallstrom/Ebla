namespace Ebla.Application.Common.Responses
{
    public record LoanResponse(
        int Id, 
        DateTime DueDate, 
        DateTime? Returned, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        BookSlimDto Book, 
        Guid UserId);
}