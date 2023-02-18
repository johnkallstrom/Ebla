namespace Ebla.Web.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly IIdentityService _identityService;

        public LoginModel(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            bool succeeded = await _identityService.LoginAsync(Username, Password);

            if (succeeded)
            {
                return RedirectToPage("/Start");
            }

            return null;
        }
    }
}
