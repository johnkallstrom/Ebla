namespace Ebla.Web.Features.Reservations
{
    public partial class Index
    {
        [Inject]
        public IHttpService<ReservationViewModel> HttpService { get; set; }

        public IEnumerable<ReservationViewModel> ReservationList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ReservationList = await HttpService.GetListAsync(Endpoints.Reservations);
        }
    }
}