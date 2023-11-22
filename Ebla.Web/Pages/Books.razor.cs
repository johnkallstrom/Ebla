namespace Ebla.Web.Pages
{
    public partial class Books
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<BookViewModel> BookList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync("/api/books");

                if (response.IsSuccessStatusCode)
                {
                    BookList = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
                }
                else
                {
                    Errors = new List<string> { await response.Content.ReadAsStringAsync() };
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}