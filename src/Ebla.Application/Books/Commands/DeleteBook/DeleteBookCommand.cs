namespace Ebla.Application.Books.Commands
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
