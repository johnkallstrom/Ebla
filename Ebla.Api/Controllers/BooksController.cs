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

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _mediator.Send(new GetBooksQuery());

            return books;
        }

        [HttpGet("{bookId}")]
        public async Task<BookDto> GetById(int bookId)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = bookId });

            return book;
        }
    }
}
