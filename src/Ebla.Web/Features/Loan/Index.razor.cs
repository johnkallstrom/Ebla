namespace Ebla.Web.Features.Loan
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LoanViewModel> Loans { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Loans);

                if (response.IsSuccessStatusCode)
                {
                    Loans = await response.Content.ReadFromJsonAsync<List<LoanViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
