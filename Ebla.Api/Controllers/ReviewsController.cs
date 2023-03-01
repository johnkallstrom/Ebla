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
        /// Get all reviews
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<IEnumerable<ReviewDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
