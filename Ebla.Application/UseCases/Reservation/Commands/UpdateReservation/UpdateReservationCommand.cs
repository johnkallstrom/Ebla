namespace Ebla.Application.UseCases.Reservation.Commands
{
    public class UpdateReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
