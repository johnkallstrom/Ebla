namespace Ebla.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GenreDto>> GetAll()
        {
            var genres = await _mediator.Send(new GetGenresQuery());

            return genres;
        }
    }
}
