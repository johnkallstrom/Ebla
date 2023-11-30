﻿using Ebla.Application.Interfaces;

namespace Ebla.Application.Reviews.Queries.GetReviewsByUserId
{
    public class GetReviewsByUserIdQueryHandler : IRequestHandler<GetReviewsByUserIdQuery, IEnumerable<ReviewResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _repository;

        public GetReviewsByUserIdQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewResponse>> Handle(GetReviewsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetReviewListByUserIdAsync(request.UserId);

            return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        }
    }
}
