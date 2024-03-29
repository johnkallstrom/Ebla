﻿namespace Ebla.Application.Loans.Queries
{
    public class GetLoansQueryHandler : IRequestHandler<GetLoansQuery, IEnumerable<LoanDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;

        public GetLoansQueryHandler(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> Handle(GetLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _repository.GetAllLoansAsync();

            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }
    }
}
