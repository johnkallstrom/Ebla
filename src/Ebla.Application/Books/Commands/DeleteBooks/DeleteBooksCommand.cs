namespace Ebla.Application.Books.Commands
{
    public class DeleteBooksCommand : IRequest<Result>
    {
        public int[] Ids { get; set; }
    }
}
