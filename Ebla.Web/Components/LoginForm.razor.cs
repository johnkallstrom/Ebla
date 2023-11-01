namespace Ebla.Web.Components
{
    public partial class LoginForm
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        [Inject]
        public ICookieStorage CookieStorage { get; set; }

        public LoginModel Model { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginModel();
            Errors = new List<string>();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await CookieStorage.InitializeAsync();
            }
        }

        public async Task Submit()
        {
            var response = await UserHttpService.LoginUserAsync(Model.Username, Model.Password);

            if (response.Succeeded)
            {
                Errors.Clear();
                await CookieStorage.SetAsync("token", response.Token);
            }
            else
            {
                Errors = response.Errors.ToList();
            }
        }
    }
}