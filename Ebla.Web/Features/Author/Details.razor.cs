namespace Ebla.Web.Features.Author
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public int AuthorId { get; set; }

        public AuthorViewModel Author { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Authors}/{AuthorId}");

            if (response.IsSuccessStatusCode)
            {
                Author = await response.Content.ReadFromJsonAsync<AuthorViewModel>();
            }
        }
    }
}
