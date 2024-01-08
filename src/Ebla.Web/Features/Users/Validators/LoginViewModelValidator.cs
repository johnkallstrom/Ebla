namespace Ebla.Web.Features.Users.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter a username");
            RuleFor(x => x.Password).MinimumLength(8).NotEmpty().WithMessage("Please enter a valid password, must be atleast 8 characters in length");
        }
    }
}
