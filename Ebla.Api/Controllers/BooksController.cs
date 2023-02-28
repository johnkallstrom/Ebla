namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _mediator.Send(new GetBooksQuery());

            return books;
        }
    }
}
