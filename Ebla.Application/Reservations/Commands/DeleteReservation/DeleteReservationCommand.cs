namespace Ebla.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
