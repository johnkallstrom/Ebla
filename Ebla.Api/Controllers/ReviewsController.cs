namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get reviews by book id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId:int}")]
        public async Task<IEnumerable<ReviewDto>> GetByBookId(int bookId)
        {
            var reviews = await _mediator.Send(new GetReviewsByBookIdQuery { BookId = bookId });

            return reviews;
        }

        /// <summary>
        /// Get all user reviews
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId:guid}")]
        public async Task<IEnumerable<ReviewDto>> GetByUserId(Guid userId)
        {
            var reviews = await _mediator.Send(new GetReviewsByUserIdQuery { UserId = userId });

            return reviews;
        }
    }
}
