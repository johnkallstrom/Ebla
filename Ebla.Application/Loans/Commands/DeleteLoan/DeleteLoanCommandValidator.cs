namespace Ebla.Application.Loans.Commands.DeleteLoan
{
    public class DeleteLoanCommandValidator : AbstractValidator<DeleteLoanCommand>
    {
        public DeleteLoanCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
