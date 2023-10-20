namespace Ebla.Web.Components
{
    public partial class Login
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();

        public void LoginFormSubmitted()
        {
            Console.WriteLine($"Username: {LoginModel.Username}");
            Console.WriteLine($"Password: {LoginModel.Password}");
        }
    }
}