namespace Ebla.Web.Components
{
    public partial class Login
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        public LoginModel Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginModel();
        }

        public async Task Submit()
        {
            var result = await UserHttpService.LoginUserAsync(Model.Username, Model.Password);

            Console.WriteLine(result);
        }
    }
}