namespace Ebla.Application.Loans.Queries
{
    public class GetLoansByUserIdQueryHandler : IRequestHandler<GetLoansByUserIdQuery, IEnumerable<LoanDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;

        public GetLoansByUserIdQueryHandler(
            IMapper mapper, 
            ILoanRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LoanDto>> Handle(GetLoansByUserIdQuery request, CancellationToken cancellationToken)
        {
            var loans = await _repository.GetLoansByUserIdAsync(request.UserId);

            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }
    }
}
