namespace Ebla.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
