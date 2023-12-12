namespace Ebla.Web.Features.User
{
    public partial class Profile
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public Guid UserId { get; set; }

        public UserViewModel User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Users}/{UserId}");

            if (response.IsSuccessStatusCode)
            {
                User = await response.Content.ReadFromJsonAsync<UserViewModel>();
            }
        }
    }
}