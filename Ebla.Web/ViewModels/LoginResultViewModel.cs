namespace Ebla.Web.ViewModels
{
    public class LoginResultViewModel
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
        public UserViewModel User { get; set; }
    }
}
