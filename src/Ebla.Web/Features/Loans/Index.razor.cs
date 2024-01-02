namespace Ebla.Web.Features.Loans
{
    public partial class Index
    {
        [Inject]
        public IGenericHttpService<LoanViewModel> HttpService { get; set; }

        public IEnumerable<LoanViewModel> LoanList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LoanList = await HttpService.GetListAsync(Endpoints.Loans);
        }
    }
}