namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IAuthenticationService AuthenticatonService { get; set; }

        public LoginViewModel ViewModel { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            var result = await AuthenticatonService.LoginAsync(ViewModel.Username, ViewModel.Password);

            if (result.Errors.Count() > 0)
            {
                Errors = result.Errors.ToList();
            }
        }
    }
}