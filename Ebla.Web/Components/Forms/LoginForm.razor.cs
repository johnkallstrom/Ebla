namespace Ebla.Web.Components.Forms
{
    public partial class LoginForm
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
                var response = await HttpService.PostAsync(Endpoints.Login, Model);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ResultViewModel<string>>();

                    if (result.Succeeded)
                    {
                        await LocalStorage.SetItemAsStringAsync("token", result.Data);
                        NavigationManager.NavigateToStartPageAndRefresh();
                    }
                    else
                    {
                        Errors = result.Errors.ToList();
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