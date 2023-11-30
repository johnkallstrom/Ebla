namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
