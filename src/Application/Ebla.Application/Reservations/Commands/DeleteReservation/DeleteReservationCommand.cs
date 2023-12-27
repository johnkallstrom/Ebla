namespace Ebla.Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
