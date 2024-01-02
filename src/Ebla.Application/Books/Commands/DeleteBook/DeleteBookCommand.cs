namespace Ebla.Application.Books.Commands
{
    public class DeleteBookCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
