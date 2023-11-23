namespace Ebla.Web.Pages
{
    public partial class Users
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<UserViewModel> UserList { get; set; }
        public List<string> Errors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Users);

                if (response.IsSuccessStatusCode)
                {
                    UserList = await response.Content.ReadFromJsonAsync<List<UserViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
