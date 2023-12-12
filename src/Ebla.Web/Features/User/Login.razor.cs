namespace Ebla.Web.Features.User
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginViewModel Model { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            Errors.Clear();

            try
            {
                var httpResponse = await HttpService.PostAsync(Endpoints.Login, Model);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadFromJsonAsync<Result<string>>();

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
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
            }
        }
    }
}
