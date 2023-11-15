namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IAuthHttpService AuthHttpService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginViewModel ViewModel { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            var result = await AuthHttpService.LoginUserAsync(ViewModel.Username, ViewModel.Password);

            if (result.Succeeded)
            {
                NavigationManager.ReloadStartPage();
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }
    }
}