namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<CreateReservationCommandResponse> Create([FromBody] CreateReservationCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
