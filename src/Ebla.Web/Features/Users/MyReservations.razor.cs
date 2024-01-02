namespace Ebla.Web.Features.Users
{
    public partial class MyReservations
    {
        [Parameter]
        public Guid UserId { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public List<ReservationViewModel> Reservations { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Reservations}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                Reservations = await response.Content.ReadFromJsonAsync<List<ReservationViewModel>>();
            }
        }
    }
}
