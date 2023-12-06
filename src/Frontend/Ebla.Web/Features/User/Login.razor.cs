namespace Ebla.Web.Features.User
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; }
    }
}
