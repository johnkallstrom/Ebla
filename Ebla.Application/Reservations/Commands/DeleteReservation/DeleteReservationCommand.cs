using Ebla.Application.Common.Results;

namespace Ebla.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
