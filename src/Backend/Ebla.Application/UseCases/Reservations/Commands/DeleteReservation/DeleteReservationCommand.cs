namespace Ebla.Application.UseCases.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
