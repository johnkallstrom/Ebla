namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
