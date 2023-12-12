namespace Ebla.Application.UseCases.Reservations.Responses
{
    public record ReservationDto(
        int Id,
        DateTime ExpiresOn,
        DateTime CreatedOn,
        DateTime? LastModified,
        BookSlimDto Book,
        Guid UserId);
}