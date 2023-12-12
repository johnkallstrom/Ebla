namespace Ebla.Application.UseCases.Loans.Responses
{
    public record LoanDto(
        int Id,
        DateTime DueDate,
        DateTime? Returned,
        DateTime CreatedOn,
        DateTime? LastModified,
        BookSlimDto Book,
        Guid UserId);
}