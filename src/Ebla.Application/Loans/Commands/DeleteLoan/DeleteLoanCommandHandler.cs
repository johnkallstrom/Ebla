namespace Ebla.Application.Loans.Commands
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Response>
    {
        private readonly IGenericRepository<Loan> _genericRepository;

        public DeleteLoanCommandHandler(IGenericRepository<Loan> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Response> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteLoanCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var loanToDelete = await _genericRepository.GetByIdAsync(request.Id);
                if (loanToDelete is null)
                {
                    throw new NotFoundException(nameof(loanToDelete), request.Id);
                }

                _genericRepository.Delete(loanToDelete);
                await _genericRepository.SaveAsync();

                return Response.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}
