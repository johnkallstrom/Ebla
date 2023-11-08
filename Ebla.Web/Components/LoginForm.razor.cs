namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public LoginViewModel ViewModel { get; set; }
        public List<string> Errors { get; set; }
        public bool ShowAlert { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            ShowAlert = false;
            var result = await UserHttpService.LoginUserAsync(ViewModel.Username, ViewModel.Password);

            if (result.Succeeded)
            {
                ClearForm();
                ShowAlert = true;
                await LocalStorage.SetItemAsStringAsync("token", result.Data);
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }

        private void ClearForm()
        {
            Errors.Clear();
            ViewModel.Username = string.Empty;
            ViewModel.Password = string.Empty;
        }
    }
}