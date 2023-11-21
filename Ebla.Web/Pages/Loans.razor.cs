namespace Ebla.Web.Pages
{
    public partial class Loans
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LoanViewModel> LoanList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync("/api/loans");

                if (response.IsSuccessStatusCode)
                {
                    LoanList = await response.Content.ReadFromJsonAsync<List<LoanViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
