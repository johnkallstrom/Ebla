namespace Ebla.Web.Features.Author
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<AuthorViewModel> Authors { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Authors);

                if (response.IsSuccessStatusCode)
                {
                    Authors = await response.Content.ReadFromJsonAsync<List<AuthorViewModel>>();
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
