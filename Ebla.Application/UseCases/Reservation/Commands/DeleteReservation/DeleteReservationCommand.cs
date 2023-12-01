namespace Ebla.Application.UseCases.Reservation.Commands
{
    public class DeleteReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
