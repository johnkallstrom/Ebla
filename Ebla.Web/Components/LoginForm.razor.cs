namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        public LoginViewModel ViewModel { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new LoginViewModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            var response = await UserHttpService.LoginUserAsync(ViewModel.Username, ViewModel.Password);

            if (response.Succeeded)
            {
                Errors.Clear();
            }
            else
            {
                Errors = response.Errors.ToList();
            }
        }
    }
}