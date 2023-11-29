namespace Ebla.Web.Features.Library
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LibraryViewModel> Libraries { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Libraries);

                if (response.IsSuccessStatusCode)
                {
                    Libraries = await response.Content.ReadFromJsonAsync<List<LibraryViewModel>>();
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
