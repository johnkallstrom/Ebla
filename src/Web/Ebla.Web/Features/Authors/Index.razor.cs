namespace Ebla.Web.Features.Authors
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<AuthorViewModel> AuthorList { get; set; } = new List<AuthorViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Authors}/all");

            if (response.IsSuccessStatusCode)
            {
                AuthorList = await response.Content.ReadFromJsonAsync<List<AuthorViewModel>>();
            }
        }
    }
}