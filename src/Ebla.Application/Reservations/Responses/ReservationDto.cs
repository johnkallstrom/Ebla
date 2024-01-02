namespace Ebla.Application.Reservations.Responses
{
    public record ReservationDto(
        int Id,
        DateTime ExpiresOn,
        DateTime CreatedOn,
        DateTime? LastModified,
        BookSlimDto Book,
        Guid UserId);
}