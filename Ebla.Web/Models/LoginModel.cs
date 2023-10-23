namespace Ebla.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
