
namespace Ebla.Web.Pages
{
    public partial class Users
    {
        [Inject]
        public IUserHttpService UserHttpService { get; set; }

        public List<UserViewModel> UserList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserList = await UserHttpService.GetAllAsync();
        }
    }
}
