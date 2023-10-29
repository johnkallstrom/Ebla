using Microsoft.JSInterop;

namespace Ebla.Web.Components
{
    public partial class Login
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public LoginModel Model { get; set; }
        public List<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginModel();
            Errors = new List<string>();
        }

        public async Task Submit()
        {
            var response = await UserHttpService.LoginUserAsync(Model.Username, Model.Password);

            if (response.Succeeded)
            {
                Errors.Clear();
                await JSRuntime.InvokeVoidAsync("storeToken", response.Token);
            }
            else
            {
                Errors = response.Errors.ToList();
            }
        }
    }
}