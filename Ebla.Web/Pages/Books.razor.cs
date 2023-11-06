namespace Ebla.Web.Pages
{
    public partial class Books
    {
        [Inject]
        public IBookHttpService BookHttpService { get; set; }

        public List<BookViewModel> BookList { get; set; }
        public string[] Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await BookHttpService.GetAllAsync();

            if (result.Succeeded)
            {
                BookList = result.Data;
            }
            else
            {
                Errors = result.Errors;
            }
        }
    }
}