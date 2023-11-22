namespace Ebla.Web.Pages
{
    public partial class Authors
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<AuthorViewModel> AuthorList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync("/api/authors");

                if (response.IsSuccessStatusCode)
                {
                    AuthorList = await response.Content.ReadFromJsonAsync<List<AuthorViewModel>>();
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
