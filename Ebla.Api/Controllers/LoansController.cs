﻿namespace Ebla.Api.Controllers
{
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
        [HasReadAccess]
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
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Result<int>> Create([FromBody] CreateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }


        /// <summary>
        /// Update a loan
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut("update")]
        public async Task<Result> Update([FromBody] UpdateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete a loan
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete/{id}")]
        public async Task<Result> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLoanCommand { Id = id });

            return result;
        }
    }
}
