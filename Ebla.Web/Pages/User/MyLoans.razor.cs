namespace Ebla.Web.Pages.User
{
    public partial class MyLoans
    {
        [Parameter]
        public Guid UserId { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LoanViewModel> LoanList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Loans}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                LoanList = await response.Content.ReadFromJsonAsync<List<LoanViewModel>>();
            }
        }
    }
}
