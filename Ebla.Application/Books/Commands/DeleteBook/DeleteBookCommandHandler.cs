﻿namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Response>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToDelete = await _repository.GetByIdAsync(request.Id);
                if (bookToDelete is null)
                {
                    throw new NotFoundException(nameof(bookToDelete), request.Id);
                }

                _repository.Delete(bookToDelete);
                await _repository.SaveAsync();

                return Response.Success();
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}
