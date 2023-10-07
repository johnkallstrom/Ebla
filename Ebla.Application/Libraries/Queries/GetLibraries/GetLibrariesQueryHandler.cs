﻿namespace Ebla.Application.Libraries.Queries.GetLibraries
{
    public class GetLibrariesQueryHandler : IRequestHandler<GetLibrariesQuery, IEnumerable<LibraryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _repository;

        public GetLibrariesQueryHandler(IMapper mapper, ILibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LibraryDto>> Handle(GetLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _repository.GetAllLibrariesAsync();

            return _mapper.Map<IEnumerable<LibraryDto>>(libraries);
        }
    }
}
