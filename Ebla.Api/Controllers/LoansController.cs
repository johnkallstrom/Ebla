namespace Ebla.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all user loans
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<LoanDto>> GetByUserId(Guid userId)
        {
            var loans = await _mediator.Send(new GetLoansByUserIdQuery { UserId = userId });

            return loans;
        }

        /// <summary>
        /// Create a new loan
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IResult<int>> Create([FromBody] CreateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
