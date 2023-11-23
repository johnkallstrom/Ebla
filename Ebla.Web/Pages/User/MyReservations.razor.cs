namespace Ebla.Web.Pages.User
{
    public partial class MyReservations
    {
        [Parameter]
        public Guid UserId { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public List<ReservationViewModel> ReservationList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Reservations}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                ReservationList = await response.Content.ReadFromJsonAsync<List<ReservationViewModel>>();
            }
        }
    }
}
