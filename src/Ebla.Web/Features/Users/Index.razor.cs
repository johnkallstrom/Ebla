namespace Ebla.Web.Features.Users
{
    public partial class Index
    {
        [Inject]
        public IGenericHttpService<UserViewModel> HttpService { get; set; }

        public IEnumerable<UserViewModel> UserList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserList = await HttpService.GetListAsync(Endpoints.Users);
        }
    }
}
