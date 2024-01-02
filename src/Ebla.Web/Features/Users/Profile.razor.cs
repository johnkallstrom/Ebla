namespace Ebla.Web.Features.Users
{
    public partial class Profile
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public Guid UserId { get; set; }

        public UserViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Users}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<UserViewModel>();
            }
        }
    }
}