using Ebla.Application.Common.Results;

namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
