namespace Ebla.Web.Features.Books.Components
{
    public partial class EditFormDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Inject]
        public IHttpService<Response> HttpService { get; set; }

        [Inject]
        public IBookHttpService BookHttpService { get; set; }

        [Parameter]
        public int? BookId { get; set; }

        public EditBookViewModel Model { get; set; } = new EditBookViewModel();

		protected override async Task OnInitializedAsync()
		{
            if (BookId.HasValue)
            {
				var book = await BookHttpService.GetAsync(BookId.Value);
				if (book is not null)
				{
					Model = ToEditBookViewModel(book);
				}
			}
		}

        private EditBookViewModel ToEditBookViewModel(BookViewModel book)
        {
            return new EditBookViewModel
            {
				Id = book.Id,
			    Title = book.Title,
			    Description = book.Description,
			    Pages = book.Pages,
			    Published = book.Published,
			    Language = book.Language,
			    Country = book.Country,
			    Image = book.Image
		    };
        }
    }
}
