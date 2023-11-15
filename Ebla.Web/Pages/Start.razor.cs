

namespace Ebla.Web.Pages
{
    public partial class Start
    {
        [Inject]
        public IAuthHttpService AuthHttpService { get; set; }

        public bool IsAuthenticated { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsAuthenticated = await AuthHttpService.IsAuthenticated();
        }
    }
}
