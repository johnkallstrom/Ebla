namespace Ebla.Web.Components
{
    public partial class Login
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        public LoginModel LoginModel { get; set; } = new LoginModel();

        public async Task LoginFormSubmitted()
        {
            await UserHttpService.LoginUserAsync(LoginModel.Username, LoginModel.Password);
        }
    }
}