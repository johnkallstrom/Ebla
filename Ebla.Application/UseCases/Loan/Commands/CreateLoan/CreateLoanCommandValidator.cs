namespace Ebla.Application.UseCases.Loan.Commands
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.UserId).NotNull().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
