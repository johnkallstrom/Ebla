namespace Ebla.Web.Features.Users
{
    public partial class Login
    {
        [Inject]
        public IHttpService<Response<string>> HttpService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginViewModel Model { get; set; } = new LoginViewModel();
        public List<string> Errors { get; set; } = new List<string>();

        public async Task Submit()
        {
            Errors.Clear();

            try
            {
                var result = await HttpService.PostAsync(Endpoints.Login, Model);
                if (result.Succeeded)
                {
                    await LocalStorage.SetItemAsStringAsync("token", result.Data);
                    NavigationManager.NavigateToAndRefresh(NavigationManager.BaseUri);
                }
                else
                {
                    Errors.AddRange(result.Errors);
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
