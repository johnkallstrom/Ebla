namespace Ebla.Web.Features.Users
{
    public partial class MyLoans
    {
        [Parameter]
        public Guid UserId { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LoanViewModel> Loans { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Loans}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                Loans = await response.Content.ReadFromJsonAsync<List<LoanViewModel>>();
            }
        }
    }
}
