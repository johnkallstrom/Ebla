namespace Ebla.Application.UseCases.Books.Commands
{
    public class DeleteBookCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
