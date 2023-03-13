namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<IResult<int>>
    {
        public int Id { get; set; }
    }
}
