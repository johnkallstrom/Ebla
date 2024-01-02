namespace Ebla.Web.Features.Reservations
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<ReservationViewModel> Reservations { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Reservations);

                if (response.IsSuccessStatusCode)
                {
                    Reservations = await response.Content.ReadFromJsonAsync<List<ReservationViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
