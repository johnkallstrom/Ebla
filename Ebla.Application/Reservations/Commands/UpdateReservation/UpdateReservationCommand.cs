namespace Ebla.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
