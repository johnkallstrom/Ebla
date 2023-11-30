﻿using Ebla.Application.Common.Results;
using Ebla.Application.Interfaces;

namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<int>>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToAdd = _mapper.Map<Book>(request);
                bookToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(bookToAdd);
                await _repository.SaveAsync();

                return Result<int>.Success(bookToAdd.Id);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result<int>.Failure(errors);
        }
    }
}
