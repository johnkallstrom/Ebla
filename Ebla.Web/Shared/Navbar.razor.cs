namespace Ebla.Web.Shared
{
    public partial class Navbar
    {
        [Inject]
        public IAuthHttpService AuthHttpService { get; set; }

        public bool IsAuthenticated { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsAuthenticated = await AuthHttpService.IsAuthenticated();
        }

        public async Task SignOut()
        {
            await AuthHttpService.SignOutAsync();
        }
    }
}
