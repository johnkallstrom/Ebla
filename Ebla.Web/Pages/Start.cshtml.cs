namespace Ebla.Web.Pages
{
    public class StartModel : PageModel
    {
        private readonly IMediator _mediator;

        public StartModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
        }
    }
}
