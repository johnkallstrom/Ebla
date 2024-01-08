namespace Ebla.Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
