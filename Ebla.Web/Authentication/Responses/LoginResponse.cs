namespace Ebla.Web.Authentication.Responses
{
    public class LoginResponse
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
        public UserViewModel User { get; set; }
    }
}
