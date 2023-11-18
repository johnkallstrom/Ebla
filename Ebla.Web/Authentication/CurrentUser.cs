namespace Ebla.Web.Authentication
{
    public class CurrentUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
