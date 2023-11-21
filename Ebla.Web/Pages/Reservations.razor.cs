namespace Ebla.Web.Pages
{
    public partial class Reservations
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<ReservationViewModel> ReservationList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync("/api/reservations");

                if (response.IsSuccessStatusCode)
                {
                    ReservationList = await response.Content.ReadFromJsonAsync<List<ReservationViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
