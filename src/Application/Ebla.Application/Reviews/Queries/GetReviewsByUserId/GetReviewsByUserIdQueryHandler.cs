namespace Ebla.Application.Reviews.Queries
{
    public class GetReviewsByUserIdQueryHandler : IRequestHandler<GetReviewsByUserIdQuery, IEnumerable<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _repository;

        public GetReviewsByUserIdQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetReviewListByUserIdAsync(request.UserId);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
    }
}
