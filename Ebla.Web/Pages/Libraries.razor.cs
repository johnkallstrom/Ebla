namespace Ebla.Web.Pages
{
    public partial class Libraries
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LibraryViewModel> LibraryList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync("/api/libraries");

                if (response.IsSuccessStatusCode)
                {
                    LibraryList = await response.Content.ReadFromJsonAsync<List<LibraryViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
