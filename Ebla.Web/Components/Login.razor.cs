namespace Ebla.Web.Components
{
    public partial class Login
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        public LoginRequest Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginRequest();
        }

        public async Task Submit()
        {
            var result = await UserHttpService.LoginUserAsync(Model.Username, Model.Password);

            if (result.Succeeded)
            {
                Console.WriteLine(result.Token);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.Error.WriteLine(error);
                }
            }
        }
    }
}