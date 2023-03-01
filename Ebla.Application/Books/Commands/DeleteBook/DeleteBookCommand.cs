namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<DeleteBookCommandResponse>
    {
        public int Id { get; set; }
    }
}
