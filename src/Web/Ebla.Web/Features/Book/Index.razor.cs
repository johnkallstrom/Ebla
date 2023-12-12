namespace Ebla.Web.Features.Book
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<BookViewModel> Books { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Books);

                if (response.IsSuccessStatusCode)
                {
                    Books = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
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