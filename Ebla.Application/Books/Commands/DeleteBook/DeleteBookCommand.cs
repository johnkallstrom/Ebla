namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
